using LeaveFormSchool.Application.Services;
using LeaveFormSchool.Application.ViewModels;
using LeaveFormSchool.Core.DataModels;
using LeaveFormSchool.Core.Enums;
using LeaveFormSchool.EntityFramework.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace LeaveFormSchool.Controllers
{
    public class LeaveFormController : Controller
    {
        // GET: LeaveForm
        public ActionResult Index()
        {
            if (Session["sIDNo"] == null)
            {
                return RedirectToAction("../Home/Index");
            }

            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            List<LeaveFormList> leaveFormLists = new List<LeaveFormList>();
            string sIDNo = Session["sIDNo"].ToString();
            var applicationUser = db.ApplicationUser.FirstOrDefault(x => x.LogonId == sIDNo);
            //進行中包含:已申請,已受理,不受理
            var processInstanceTableList = db.ProcessInstanceTable.Where(x => (x.PITStatusId != 3 && x.PITStatusId != 4) && (x.StarterId == applicationUser.Id || x.ToDoerId == applicationUser.Id)).OrderByDescending(x => x.Id).ToList();

            //分頁邏輯
            var pagnum = 1; //取得資料的起始頁數
            var pagedata = 2; //每頁顯示資料筆數
            var pageStar = (processInstanceTableList.Count() == 0) ? 0 : ((pagnum - 1) * pagedata) + 1; //取得起點數
            int leaveFormCount = processInstanceTableList.Count(); //請假單數量
            int totPage = 1; //資料總頁數
            if (leaveFormCount % pagedata != 0)
                totPage = (leaveFormCount / pagedata) + 1;
            else
                totPage = (leaveFormCount / pagedata);

            var PagerData = CommonToolServices.GetDisplayPages(pagnum, pagedata, totPage);
            ViewBag.dataPage = PagerData;

            var pageEnd = 1; //取得末點數
            var pageMaxNum = pagnum * pagedata; //第pagnum頁的最大筆數
            if (leaveFormCount / pageMaxNum > 0)
                pageEnd = pageMaxNum;
            else
                pageEnd = leaveFormCount;

            if (pageStar != 0)
            {
                for (int i = pageStar; i <= pageEnd; i++)
                {
                    LeaveFormList leaveFormList = new LeaveFormList();
                    leaveFormList.ProcessInstanceTablesId = processInstanceTableList[i - 1].Id;
                    leaveFormList.LeaveFormId = processInstanceTableList[i - 1].LeaveFormId.Value;
                    leaveFormList.StarterString = processInstanceTableList[i - 1].Starter + " (" + processInstanceTableList[i - 1].LeaveForm.LogonId + ")"; //ex: 林XX (Z12345678)
                    leaveFormList.LeaveFormNo = processInstanceTableList[i - 1].LeaveFormNo;
                    leaveFormList.TypeOfLeaveName = processInstanceTableList[i - 1].LeaveForm.TypeOfLeave.TypeOfLeaveName;
                    leaveFormList.BeginDate = processInstanceTableList[i - 1].LeaveForm.BeginDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00
                    leaveFormList.EndDate = processInstanceTableList[i - 1].LeaveForm.EndDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00;
                    leaveFormList.IsUserEmp = (processInstanceTableList[i - 1].LeaveForm.ApplicationUser.Identity == Identity.E) ? true : false;

                    var processNodeTableId = processInstanceTableList[i - 1].ProcessNodeTableId;
                    var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.Id == processNodeTableId);
                    if (processInstanceTableList[i - 1].PITStatusId == 1)
                    {
                        leaveFormList.Status = "已申請";
                    }
                    else if (processInstanceTableList[i - 1].PITStatusId == 2)
                    {
                        leaveFormList.Status = processNodeTable.NodeName + ": 已受理";
                    }
                    else if (processInstanceTableList[i - 1].PITStatusId == 3)
                    {
                        leaveFormList.Status = "已撤銷";
                    }
                    else if (processInstanceTableList[i - 1].PITStatusId == 4)
                    {
                        leaveFormList.Status = "已結案";
                    }
                    else if (processInstanceTableList[i - 1].PITStatusId == 5)
                    {
                        leaveFormList.Status = processNodeTable.NodeName + ": 不受理";
                    }


                    leaveFormLists.Add(leaveFormList);
                }
            }

            ViewBag.leaveFormes = leaveFormLists;
            ViewBag.pagnum = pagnum;
            ViewBag.pagedata = pagedata;
            ViewBag.pageStar = pageStar;
            ViewBag.pageEnd = pageEnd;
            ViewBag.totPage = leaveFormCount;
            ViewBag.pageMaxNum = pageMaxNum;

            if (applicationUser.Identity == Identity.E)
            {
                ViewBag.isEmp = "true";
            }
            else
            {
                ViewBag.isEmp = "false";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (Session["password"] == null)
            {
                Session["sIDNo"] = null;
                Session["password"] = null;
            }
            else
            {
                //登入為page1,首頁為page2
                Session["page"] = "page2";
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult LeaveFormSearch(string status, int pagnum, int pagedata)
        {
            try
            {
                LeaveFormSchoolContext db = new LeaveFormSchoolContext();
                List<LeaveFormList> leaveFormLists = new List<LeaveFormList>();
                string sIDNo = Session["sIDNo"].ToString();
                var applicationUser = db.ApplicationUser.FirstOrDefault(x => x.LogonId == sIDNo);//分頁資料
                int leaveFormCount = 1;
                var pageStar = 1; //取得起點數
                var pageEnd = 1; //取得末點數
                int totPage = 1; //資料總頁數
                var PagerData = CommonToolServices.GetDisplayPages(pagnum, pagedata, leaveFormLists.Count());

                if (status == "進行中")
                {
                    //進行中包含:已申請,已受理,不受理
                    var processInstanceTableList = db.ProcessInstanceTable.Where(x => (x.PITStatusId != 3 && x.PITStatusId != 4) && (x.StarterId == applicationUser.Id || x.ToDoerId == applicationUser.Id)).OrderByDescending(x => x.Id).ToList();

                    //分頁邏輯
                    pageStar = (processInstanceTableList.Count() == 0) ? 0 : ((pagnum - 1) * pagedata) + 1; //取得起點數
                    leaveFormCount = processInstanceTableList.Count(); //請假單數量
                    if (leaveFormCount % pagedata != 0)
                        totPage = (leaveFormCount / pagedata) + 1;
                    else
                        totPage = (leaveFormCount / pagedata);

                    PagerData = CommonToolServices.GetDisplayPages(pagnum, pagedata, totPage);

                    var pageMaxNum = pagnum * pagedata; //第pagnum頁的最大筆數
                    if (leaveFormCount / pageMaxNum > 0)
                        pageEnd = pageMaxNum;
                    else
                        pageEnd = leaveFormCount;

                    if (pageStar != 0)
                    {
                        for (int i = pageStar; i <= pageEnd; i++)
                        {
                            LeaveFormList leaveFormList = new LeaveFormList();
                            leaveFormList.ProcessInstanceTablesId = processInstanceTableList[i - 1].Id;
                            leaveFormList.LeaveFormId = processInstanceTableList[i - 1].LeaveFormId.Value;
                            leaveFormList.StarterString = processInstanceTableList[i - 1].Starter + " (" + processInstanceTableList[i - 1].LeaveForm.LogonId + ")"; //ex: 林XX (Z12345678)
                            leaveFormList.LeaveFormNo = processInstanceTableList[i - 1].LeaveFormNo;
                            leaveFormList.TypeOfLeaveName = processInstanceTableList[i - 1].LeaveForm.TypeOfLeave.TypeOfLeaveName;
                            leaveFormList.BeginDate = processInstanceTableList[i - 1].LeaveForm.BeginDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00
                            leaveFormList.EndDate = processInstanceTableList[i - 1].LeaveForm.EndDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00;
                            leaveFormList.IsUserEmp = (processInstanceTableList[i - 1].LeaveForm.ApplicationUser.Identity == Identity.E) ? true : false;

                            var processNodeTableId = processInstanceTableList[i - 1].ProcessNodeTableId;
                            var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.Id == processNodeTableId);
                            if (processInstanceTableList[i - 1].PITStatusId == 1)
                            {
                                leaveFormList.Status = "已申請";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 2)
                            {
                                leaveFormList.Status = processNodeTable.NodeName + ": 已受理";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 3)
                            {
                                leaveFormList.Status = "已撤銷";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 4)
                            {
                                leaveFormList.Status = "已結案";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 5)
                            {
                                leaveFormList.Status = processNodeTable.NodeName + ": 不受理";
                            }

                            leaveFormLists.Add(leaveFormList);
                        }
                    }


                }
                else if (status == "已完成")
                {
                    //已完成包含:已同意
                    var processInstanceTableList = db.ProcessInstanceTable.Where(x => x.PITStatusId == 4 && x.StarterId == applicationUser.Id).OrderByDescending(x => x.Id).ToList();

                    //分頁邏輯
                    pageStar = (processInstanceTableList.Count() == 0) ? 0 : ((pagnum - 1) * pagedata) + 1; //取得起點數
                    leaveFormCount = processInstanceTableList.Count(); //請假單數量
                    if (leaveFormCount % pagedata != 0)
                        totPage = (leaveFormCount / pagedata) + 1;
                    else
                        totPage = (leaveFormCount / pagedata);

                    PagerData = CommonToolServices.GetDisplayPages(pagnum, pagedata, totPage);

                    var pageMaxNum = pagnum * pagedata; //第pagnum頁的最大筆數
                    if (leaveFormCount / pageMaxNum > 0)
                        pageEnd = pageMaxNum;
                    else
                        pageEnd = leaveFormCount;

                    if (pageStar != 0)
                    {
                        for (int i = pageStar; i <= pageEnd; i++)
                        {
                            LeaveFormList leaveFormList = new LeaveFormList();
                            leaveFormList.ProcessInstanceTablesId = processInstanceTableList[i - 1].Id;
                            leaveFormList.LeaveFormId = processInstanceTableList[i - 1].LeaveFormId.Value;
                            leaveFormList.StarterString = processInstanceTableList[i - 1].Starter + " (" + processInstanceTableList[i - 1].LeaveForm.LogonId + ")"; //ex: 林XX (Z12345678)
                            leaveFormList.LeaveFormNo = processInstanceTableList[i - 1].LeaveFormNo;
                            leaveFormList.TypeOfLeaveName = processInstanceTableList[i - 1].LeaveForm.TypeOfLeave.TypeOfLeaveName;
                            leaveFormList.BeginDate = processInstanceTableList[i - 1].LeaveForm.BeginDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00
                            leaveFormList.EndDate = processInstanceTableList[i - 1].LeaveForm.EndDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00;
                            leaveFormList.IsUserEmp = (processInstanceTableList[i - 1].LeaveForm.ApplicationUser.Identity == Identity.E) ? true : false;

                            var processNodeTableId = processInstanceTableList[i - 1].ProcessNodeTableId;
                            var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.Id == processNodeTableId);
                            if (processInstanceTableList[i - 1].PITStatusId == 1)
                            {
                                leaveFormList.Status = "已申請";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 2)
                            {
                                leaveFormList.Status = processNodeTable.NodeName + ": 已受理";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 3)
                            {
                                leaveFormList.Status = "已撤銷";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 4)
                            {
                                leaveFormList.Status = "已結案";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 5)
                            {
                                leaveFormList.Status = processNodeTable.NodeName + ": 不受理";
                            }

                            leaveFormLists.Add(leaveFormList);
                        }
                    }
                }
                else if (status == "撤銷")
                {
                    //撤銷中包含:已撤銷
                    var processInstanceTableList = db.ProcessInstanceTable.Where(x => x.PITStatusId == 3 && x.StarterId == applicationUser.Id).OrderByDescending(x => x.Id).ToList();

                    //分頁邏輯
                    pageStar = (processInstanceTableList.Count() == 0) ? 0 : ((pagnum - 1) * pagedata) + 1; //取得起點數
                    leaveFormCount = processInstanceTableList.Count(); //請假單數量
                    if (leaveFormCount % pagedata != 0)
                        totPage = (leaveFormCount / pagedata) + 1;
                    else
                        totPage = (leaveFormCount / pagedata);

                    PagerData = CommonToolServices.GetDisplayPages(pagnum, pagedata, totPage);

                    var pageMaxNum = pagnum * pagedata; //第pagnum頁的最大筆數
                    if (leaveFormCount / pageMaxNum > 0)
                        pageEnd = pageMaxNum;
                    else
                        pageEnd = leaveFormCount;

                    if (pageStar != 0)
                    {
                        for (int i = pageStar; i <= pageEnd; i++)
                        {
                            LeaveFormList leaveFormList = new LeaveFormList();
                            leaveFormList.ProcessInstanceTablesId = processInstanceTableList[i - 1].Id;
                            leaveFormList.LeaveFormId = processInstanceTableList[i - 1].LeaveFormId.Value;
                            leaveFormList.StarterString = processInstanceTableList[i - 1].Starter + " (" + processInstanceTableList[i - 1].LeaveForm.LogonId + ")"; //ex: 林XX (Z12345678)
                            leaveFormList.LeaveFormNo = processInstanceTableList[i - 1].LeaveFormNo;
                            leaveFormList.TypeOfLeaveName = processInstanceTableList[i - 1].LeaveForm.TypeOfLeave.TypeOfLeaveName;
                            leaveFormList.BeginDate = processInstanceTableList[i - 1].LeaveForm.BeginDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00
                            leaveFormList.EndDate = processInstanceTableList[i - 1].LeaveForm.EndDate.Value.ToString("yyyy/MM/dd HH:mm"); //ex: 2021/04/25 13:00;
                            leaveFormList.IsUserEmp = (processInstanceTableList[i - 1].LeaveForm.ApplicationUser.Identity == Identity.E) ? true : false;

                            var processNodeTableId = processInstanceTableList[i - 1].ProcessNodeTableId;
                            var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.Id == processNodeTableId);
                            if (processInstanceTableList[i - 1].PITStatusId == 1)
                            {
                                leaveFormList.Status = "已申請";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 2)
                            {
                                leaveFormList.Status = processNodeTable.NodeName + ": 已受理";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 3)
                            {
                                leaveFormList.Status = "已撤銷";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 4)
                            {
                                leaveFormList.Status = "已結案";
                            }
                            else if (processInstanceTableList[i - 1].PITStatusId == 5)
                            {
                                leaveFormList.Status = processNodeTable.NodeName + ": 不受理";
                            }

                            leaveFormLists.Add(leaveFormList);
                        }
                    }
                }


                return Json(new { leaveFormes = leaveFormLists, pager = PagerData, totPage = leaveFormCount, pageStar = pageStar, pageEnd = pageEnd });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, error = false });
            }
        }

        [HttpGet]
        public ActionResult EditLeaveFormByEmployee(int processInstanceTablesId, int leaveFormId, string leaveFormNo, string status)
        {
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            if (Session["sIDNo"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            string userIDNo = Session["sIDNo"].ToString();
            var user = db.ApplicationUser.FirstOrDefault(x => x.LogonId == userIDNo);
            var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == processInstanceTablesId);
            var sIDNo = processInstanceTable.LeaveForm.LogonId;
            var applicationUser = processInstanceTable.LeaveForm.ApplicationUser;
            var nodeOrder = processInstanceTable.ProcessNodeTable.NodeOrder;


            //任職幾年
            var totalYear = (int)(DateTime.Now.Date - applicationUser.EnrollmentDate.Value.Date).TotalDays / 365;
            //任職幾天
            var date3 = (DateTime.Now.Date - applicationUser.EnrollmentDate.Value.Date).TotalDays - (365 * totalYear);
            //顯示請假狀態(第一筆:特休假,第二筆:事假,第三筆:生理假,每位員工只會有三筆資料,如果已有資料則會修改資料)
            var getLeaveStatusFormByEmployees = db.Database.SqlQuery<GetLeaveStatusFormByEmployees>(@"execute GetLeaveStatusFormByEmployees_InsertAndUpdate '" + sIDNo + "' ");

            //寫入多筆代理人
            var agent = "";
            List<string> agentList = new List<string>();
            var employees = db.Employee.Where(x => x.IsActive == true && x.LogonId != sIDNo).ToList();
            foreach (var employee in employees)
            {
                var e = employee.ApplicationUser.JobType.SchoolDepartment.Department + "-" + employee.LogonId;
                agentList.Add(e);
                if (employee.LogonId == processInstanceTable.LeaveForm.AgentLogonId)
                {
                    agent = e;
                }
            }

            //簽核流程
            var nodeSN = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NodeSN;
            var numberOfTimes = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NumberOfTimes;
            string nodeSNNext = nodeSN;
            string process = "";
            for (int i = 1; i <= numberOfTimes; i++)
            {
                var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nodeSNNext);

                if (processNodeTable.NodeOrder == 1)
                {
                    //申請人
                    if (processInstanceTable.PITStatusId == 3)
                    {
                        if (processNodeTable.NodeOrder == nodeOrder) { process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已撤銷</a></li> "; }
                        else { process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已撤銷</a></li> "; }

                    }
                    else
                    {
                        if (processNodeTable.NodeOrder == nodeOrder) { process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已申請</a></li> "; }
                        else { process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已申請</a></li> "; }

                    }


                }
                else if (2 <= processNodeTable.NodeOrder && processNodeTable.NodeOrder <= (numberOfTimes - 1))
                {
                    if (processInstanceTable.ProcessNodeTable.NodeOrder < 2)
                    {
                        if (processNodeTable.MinLeaveNum == 4)
                        {
                            //超過3天假
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:未受理</a></li> ";
                        }
                        else
                        {
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未受理</a></li> ";
                        }
                    }
                    else if (processNodeTable.NodeOrder < processInstanceTable.ProcessNodeTable.NodeOrder)
                    {
                        if (processNodeTable.MinLeaveNum == 4)
                        {
                            //超過3天假
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:已受理</a></li> ";
                        }
                        else
                        {
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> ";
                        }

                    }
                    else if (processNodeTable.NodeOrder > processInstanceTable.ProcessNodeTable.NodeOrder)
                    {
                        if (processNodeTable.MinLeaveNum == 4)
                        {
                            //超過3天假
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:未受理</a></li> ";
                        }
                        else
                        {
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未受理</a></li> ";
                        }

                    }
                    else if (processInstanceTable.ProcessNodeTable.MinLeaveNum == 4)
                    {
                        if (processInstanceTable.PITStatusId == 5)
                        {
                            //超過3天假
                            process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:不受理</a></li> ";
                        }
                        else
                        {
                            //超過3天假
                            process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:已受理</a></li> ";
                        }
                    }
                    else if (processInstanceTable.PITStatusId == 2) { process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> "; }
                    else if (processInstanceTable.PITStatusId == 3) { process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> "; }
                    else if (processInstanceTable.PITStatusId == 4) { process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> "; }
                    else if (processInstanceTable.PITStatusId == 5) { process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":不受理</a></li> "; }


                }
                else if (processNodeTable.NodeOrder == numberOfTimes)
                {
                    //結束
                    if (processInstanceTable.PITStatusId == 4)
                    {
                        process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已同意</a></li> ";
                    }
                    else
                    {
                        process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未同意</a></li> ";
                    }
                }


                if (processNodeTable.NodeName != "結案")
                {
                    nodeSNNext = processNodeTable.NextNodeSN;
                }

                if (processNodeTable.NodeOrder == 2 && processNodeTable.NodeName != "代理人")
                {
                    agent = "";
                }

            }

            //下載文件
            var leaveFormCertifiedDocs = db.LeaveFormCertifiedDoc.Where(x => x.LeaveFormId == processInstanceTable.LeaveFormId).ToList();
            List<CertifiedDocDto> CertifiedDocDtoList = new List<CertifiedDocDto>();
            foreach (var l in leaveFormCertifiedDocs)
            {
                CertifiedDocDto CertifiedDocDto = new CertifiedDocDto();
                CertifiedDocDto.Id = l.CertifiedDoc.Id;
                CertifiedDocDto.FileName = l.CertifiedDoc.FileName;
                CertifiedDocDto.FileSize = l.CertifiedDoc.FileSize;
                CertifiedDocDto.CreateDate = l.CertifiedDoc.CreateDate;

                CertifiedDocDtoList.Add(CertifiedDocDto);

            }

            //生理假規則
            var leaveForms = db.LeaveForm.Where(x => x.LogonId == sIDNo && x.IsDelete == false && x.TypeOfLeaveId == 12 && x.BeginDate.Value.Year == DateTime.Now.Year && x.BeginDate.Value.Month == DateTime.Now.Month);

            ViewBag.dataFiles = CertifiedDocDtoList;
            ViewBag.processInstanceTablesId = processInstanceTablesId;
            ViewBag.leaveFormId = leaveFormId;
            ViewBag.leaveFormNo = leaveFormNo;
            ViewBag.status = status;
            ViewBag.userName = processInstanceTable.Starter + " " + "(" + processInstanceTable.LeaveForm.LogonId + ")";
            ViewBag.leaveFormUserTime = leaveFormNo + "已使用: " + processInstanceTable.LeaveForm.TypeOfLeave.TypeOfLeaveName + (processInstanceTable.LeaveForm.TimeOff / 8) + "天又" + (processInstanceTable.LeaveForm.TimeOff % 8) + "小時"; //ex: A-20210212-1已使用: 特休假2天又0小時
            ViewBag.firstTime = applicationUser.EnrollmentDate.Value.ToString("yyyy-MM-dd") + "(任職" + totalYear + "年" + date3 + "天" + ")";
            ViewBag.specialVacation = getLeaveStatusFormByEmployees.ToList()[0].LeaveRulesString;
            ViewBag.personalLeave = getLeaveStatusFormByEmployees.ToList()[1].LeaveRulesString;
            ViewBag.physiologicalLeave = getLeaveStatusFormByEmployees.ToList()[2].LeaveRulesString;
            ViewBag.specialVacationNum = getLeaveStatusFormByEmployees.ToList()[0].RemainingLeaveHR;
            ViewBag.personalLeaveNum = getLeaveStatusFormByEmployees.ToList()[1].RemainingLeaveHR;
            ViewBag.physiologicalLeaveNum = getLeaveStatusFormByEmployees.ToList()[2].RemainingLeaveHR;
            ViewBag.typeOfLeave = processInstanceTable.LeaveForm.TypeOfLeave.TypeOfLeaveName;
            ViewBag.totalDate = processInstanceTable.LeaveForm.TimeOff;
            ViewBag.totalDay = (processInstanceTable.LeaveForm.TimeOff / 8); //工作一天8小時
            ViewBag.totalHur = (processInstanceTable.LeaveForm.TimeOff % 8);
            ViewBag.editReason = processInstanceTable.LeaveForm.Reason;
            ViewBag.agent = agent;
            ViewBag.agents = agentList;
            ViewBag.process = process;
            ViewBag.physiologicalLeaveNotice = (leaveForms.Count() > 0) ? "生理假這個月已使用" : "生理假這個月尚未使用";


            if (processInstanceTable.PITStatusId == 3 || processInstanceTable.PITStatusId == 4)
            {
                //已撤銷,已同意
                ViewBag.editBeginDate = processInstanceTable.LeaveForm.BeginDate;
                ViewBag.editEndDate = processInstanceTable.LeaveForm.EndDate;
                ViewBag.isEdit = "false";
                ViewBag.isRejectBtn = "false";
                ViewBag.isCanceledBtn = "false";
                ViewBag.isSendBtn = "false";
                ViewBag.isEditBtn = "false";
                ViewBag.isAcceptBtn = "false";

            }
            else if (processInstanceTable.PITStatusId == 5)
            {
                // 轉成字串，如果低於10，前面加上'0'
                var dateString1 = processInstanceTable.LeaveForm.BeginDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour1 = processInstanceTable.LeaveForm.BeginDate.Value.Hour;
                var min1 = processInstanceTable.LeaveForm.BeginDate.Value.Minute;
                var dateString2 = processInstanceTable.LeaveForm.EndDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour2 = processInstanceTable.LeaveForm.EndDate.Value.Hour;
                var min2 = processInstanceTable.LeaveForm.EndDate.Value.Minute;
                var hourString1 = (hour1 < 10) ? ("0" + hour1) : ("" + hour1);
                var minString1 = (min1 < 10) ? ("0" + min1) : ("" + min1);
                var hourString2 = (hour2 < 10) ? ("0" + hour2) : ("" + hour2);
                var minString2 = (min2 < 10) ? ("0" + min2) : ("" + min2);

                ViewBag.editBeginDate = dateString1 + hourString1 + ':' + minString1;
                ViewBag.editEndDate = dateString2 + hourString2 + ':' + minString2;
                //不受理
                ViewBag.isEdit = "true";
                ViewBag.isRejectBtn = "false";
                ViewBag.isCanceledBtn = "true";
                ViewBag.isSendBtn = "true";
                ViewBag.isEditBtn = "true";
                ViewBag.isAcceptBtn = "false";
            }
            else if (processInstanceTable.ToDoerId == user.Id && processInstanceTable.StarterId == user.Id)
            {
                // 轉成字串，如果低於10，前面加上'0'
                var dateString1 = processInstanceTable.LeaveForm.BeginDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour1 = processInstanceTable.LeaveForm.BeginDate.Value.Hour;
                var min1 = processInstanceTable.LeaveForm.BeginDate.Value.Minute;
                var dateString2 = processInstanceTable.LeaveForm.EndDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour2 = processInstanceTable.LeaveForm.EndDate.Value.Hour;
                var min2 = processInstanceTable.LeaveForm.EndDate.Value.Minute;
                var hourString1 = (hour1 < 10) ? ("0" + hour1) : ("" + hour1);
                var minString1 = (min1 < 10) ? ("0" + min1) : ("" + min1);
                var hourString2 = (hour2 < 10) ? ("0" + hour2) : ("" + hour2);
                var minString2 = (min2 < 10) ? ("0" + min2) : ("" + min2);

                ViewBag.editBeginDate = dateString1 + hourString1 + ':' + minString1;
                ViewBag.editEndDate = dateString2 + hourString2 + ':' + minString2;
                ViewBag.isEdit = "true";
                ViewBag.isRejectBtn = "true";
                ViewBag.isCanceledBtn = "true";
                ViewBag.isSendBtn = "false";
                ViewBag.isEditBtn = "true";
                ViewBag.isAcceptBtn = "true";
            }
            else if (processInstanceTable.ToDoerId == user.Id)
            {
                // 轉成字串，如果低於10，前面加上'0'
                var dateString1 = processInstanceTable.LeaveForm.BeginDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour1 = processInstanceTable.LeaveForm.BeginDate.Value.Hour;
                var min1 = processInstanceTable.LeaveForm.BeginDate.Value.Minute;
                var dateString2 = processInstanceTable.LeaveForm.EndDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour2 = processInstanceTable.LeaveForm.EndDate.Value.Hour;
                var min2 = processInstanceTable.LeaveForm.EndDate.Value.Minute;
                var hourString1 = (hour1 < 10) ? ("0" + hour1) : ("" + hour1);
                var minString1 = (min1 < 10) ? ("0" + min1) : ("" + min1);
                var hourString2 = (hour2 < 10) ? ("0" + hour2) : ("" + hour2);
                var minString2 = (min2 < 10) ? ("0" + min2) : ("" + min2);

                ViewBag.editBeginDate = dateString1 + hourString1 + ':' + minString1;
                ViewBag.editEndDate = dateString2 + hourString2 + ':' + minString2;
                ViewBag.isEdit = "true";
                ViewBag.isRejectBtn = "true";
                ViewBag.isCanceledBtn = "false";
                ViewBag.isSendBtn = "false";
                ViewBag.isEditBtn = "true";
                ViewBag.isAcceptBtn = "true";
            }
            else if (processInstanceTable.StarterId == user.Id)
            {
                ViewBag.editBeginDate = processInstanceTable.LeaveForm.BeginDate;
                ViewBag.editEndDate = processInstanceTable.LeaveForm.EndDate;
                ViewBag.isEdit = "false";
                ViewBag.isRejectBtn = "false";
                ViewBag.isCanceledBtn = "true";
                ViewBag.isSendBtn = "false";
                ViewBag.isEditBtn = "false";
                ViewBag.isAcceptBtn = "false";
            }

            return View();
        }

        [HttpGet]
        public ActionResult DownloadFile(int dataFilesId)
        {
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            var certifiedDoc = db.CertifiedDoc.FirstOrDefault(x => x.Id == dataFilesId);

            string filepath = Server.MapPath("/ProofOfLeaveForm/" + certifiedDoc.FileName);
            //取得檔案名稱
            string filename = System.IO.Path.GetFileName(filepath);
            //讀成串流
            Stream iStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            //回傳出檔案
            return File(iStream, "application/zip", filename);


        }

        [HttpGet]
        public ActionResult EditLeaveFormByStudent(int processInstanceTablesId, int leaveFormId, string leaveFormNo, string status)
        {
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            if (Session["sIDNo"] == null)
            {
                return RedirectToAction("../Home/Index");
            }
            string userIDNo = Session["sIDNo"].ToString();
            var user = db.ApplicationUser.FirstOrDefault(x => x.LogonId == userIDNo);
            var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == processInstanceTablesId);
            var sIDNo = processInstanceTable.LeaveForm.LogonId;
            var applicationUser = processInstanceTable.LeaveForm.ApplicationUser;
            var nodeOrder = processInstanceTable.ProcessNodeTable.NodeOrder;


            //生理假規則
            var leaveForms = db.LeaveForm.Where(x => x.LogonId == sIDNo && x.IsDelete == false && x.TypeOfLeaveId == 12 && x.BeginDate.Value.Year == DateTime.Now.Year && x.BeginDate.Value.Month == DateTime.Now.Month);

            ViewBag.physiologicalLeave = (leaveForms.Count() > 0) ? "這個月已使用" : "這個月尚未使用";

            //簽核流程
            var nodeSN = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NodeSN;
            var numberOfTimes = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NumberOfTimes;
            string nodeSNNext = nodeSN;
            string process = "";
            for (int i = 1; i <= numberOfTimes; i++)
            {
                var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nodeSNNext);

                if (processNodeTable.NodeOrder == 1)
                {
                    //申請人
                    if (processInstanceTable.PITStatusId == 3)
                    {
                        if (processNodeTable.NodeOrder == nodeOrder) { process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已撤銷</a></li> "; }
                        else { process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已撤銷</a></li> "; }

                    }
                    else
                    {
                        if (processNodeTable.NodeOrder == nodeOrder) { process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已申請</a></li> "; }
                        else { process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已申請</a></li> "; }

                    }

                }
                else if (2 <= processNodeTable.NodeOrder && processNodeTable.NodeOrder <= (numberOfTimes - 1))
                {
                    if (processInstanceTable.ProcessNodeTable.NodeOrder < 2)
                    {
                        if (processNodeTable.MinLeaveNum == 4)
                        {
                            //超過3天假
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:未受理</a></li> ";
                        }
                        else
                        {
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未受理</a></li> ";
                        }
                    }
                    else if (processNodeTable.NodeOrder < processInstanceTable.ProcessNodeTable.NodeOrder)
                    {
                        if (processNodeTable.MinLeaveNum == 4)
                        {
                            //超過3天假
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:已受理</a></li> ";
                        }
                        else
                        {
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> ";
                        }

                    }
                    else if (processNodeTable.NodeOrder > processInstanceTable.ProcessNodeTable.NodeOrder)
                    {
                        if (processNodeTable.MinLeaveNum == 4)
                        {
                            //超過3天假
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:未受理</a></li> ";
                        }
                        else
                        {
                            process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未受理</a></li> ";
                        }

                    }
                    else if (processInstanceTable.ProcessNodeTable.MinLeaveNum == 4)
                    {
                        if (processInstanceTable.PITStatusId == 5)
                        {
                            //超過3天假
                            process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:不受理</a></li> ";
                        }
                        else
                        {
                            //超過3天假
                            process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:已受理</a></li> ";
                        }
                    }
                    else if (processInstanceTable.PITStatusId == 2) { process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> "; }
                    else if (processInstanceTable.PITStatusId == 3) { process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> "; }
                    else if (processInstanceTable.PITStatusId == 4) { process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已受理</a></li> "; }
                    else if (processInstanceTable.PITStatusId == 5) { process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":不受理</a></li> "; }


                }
                else if (processNodeTable.NodeOrder == numberOfTimes)
                {
                    //結束
                    if (processInstanceTable.PITStatusId == 4)
                    {
                        process += "<li class=\"current\" ><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":已同意</a></li> ";
                    }
                    else
                    {
                        process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未同意</a></li> ";
                    }
                }


                if (processNodeTable.NodeName != "結案")
                {
                    nodeSNNext = processNodeTable.NextNodeSN;
                }

            }

            //下載文件
            var leaveFormCertifiedDocs = db.LeaveFormCertifiedDoc.Where(x => x.LeaveFormId == processInstanceTable.LeaveFormId).ToList();
            List<CertifiedDocDto> CertifiedDocDtoList = new List<CertifiedDocDto>();
            foreach (var l in leaveFormCertifiedDocs)
            {
                CertifiedDocDto CertifiedDocDto = new CertifiedDocDto();
                CertifiedDocDto.Id = l.CertifiedDoc.Id;
                CertifiedDocDto.FileName = l.CertifiedDoc.FileName;
                CertifiedDocDto.FileSize = l.CertifiedDoc.FileSize;
                CertifiedDocDto.CreateDate = l.CertifiedDoc.CreateDate;

                CertifiedDocDtoList.Add(CertifiedDocDto);

            }
            ViewBag.dataFiles = CertifiedDocDtoList;
            ViewBag.processInstanceTablesId = processInstanceTablesId;
            ViewBag.leaveFormId = leaveFormId;
            ViewBag.leaveFormNo = leaveFormNo;
            ViewBag.status = status;
            ViewBag.userName = processInstanceTable.Starter + " " + "(" + processInstanceTable.LeaveForm.LogonId + ")";
            ViewBag.typeOfLeave = processInstanceTable.LeaveForm.TypeOfLeave.TypeOfLeaveName;
            ViewBag.totalDate = processInstanceTable.LeaveForm.TimeOff;
            ViewBag.totalDay = (processInstanceTable.LeaveForm.TimeOff / 8); //工作一天8小時
            ViewBag.totalHur = (processInstanceTable.LeaveForm.TimeOff % 8);
            ViewBag.editReason = processInstanceTable.LeaveForm.Reason;
            ViewBag.process = process;


            if (processInstanceTable.PITStatusId == 3 || processInstanceTable.PITStatusId == 4)
            {
                //已撤銷,已同意
                ViewBag.editBeginDate = processInstanceTable.LeaveForm.BeginDate;
                ViewBag.editEndDate = processInstanceTable.LeaveForm.EndDate;
                ViewBag.isEdit = "false";
                ViewBag.isRejectBtn = "false";
                ViewBag.isCanceledBtn = "false";
                ViewBag.isSendBtn = "false";
                ViewBag.isEditBtn = "false";
                ViewBag.isAcceptBtn = "false";

            }
            else if (processInstanceTable.PITStatusId == 5)
            {
                // 轉成字串，如果低於10，前面加上'0'
                var dateString1 = processInstanceTable.LeaveForm.BeginDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour1 = processInstanceTable.LeaveForm.BeginDate.Value.Hour;
                var min1 = processInstanceTable.LeaveForm.BeginDate.Value.Minute;
                var dateString2 = processInstanceTable.LeaveForm.EndDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour2 = processInstanceTable.LeaveForm.EndDate.Value.Hour;
                var min2 = processInstanceTable.LeaveForm.EndDate.Value.Minute;
                var hourString1 = (hour1 < 10) ? ("0" + hour1) : ("" + hour1);
                var minString1 = (min1 < 10) ? ("0" + min1) : ("" + min1);
                var hourString2 = (hour2 < 10) ? ("0" + hour2) : ("" + hour2);
                var minString2 = (min2 < 10) ? ("0" + min2) : ("" + min2);

                ViewBag.editBeginDate = dateString1 + hourString1 + ':' + minString1;
                ViewBag.editEndDate = dateString2 + hourString2 + ':' + minString2;
                //不受理
                ViewBag.isEdit = "true";
                ViewBag.isRejectBtn = "false";
                ViewBag.isCanceledBtn = "true";
                ViewBag.isSendBtn = "true";
                ViewBag.isEditBtn = "true";
                ViewBag.isAcceptBtn = "false";
            }
            else if (processInstanceTable.ToDoerId == user.Id)
            {
                // 轉成字串，如果低於10，前面加上'0'
                var dateString1 = processInstanceTable.LeaveForm.BeginDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour1 = processInstanceTable.LeaveForm.BeginDate.Value.Hour;
                var min1 = processInstanceTable.LeaveForm.BeginDate.Value.Minute;
                var dateString2 = processInstanceTable.LeaveForm.EndDate.Value.ToString("yyyy-MM-dd") + "T";
                var hour2 = processInstanceTable.LeaveForm.EndDate.Value.Hour;
                var min2 = processInstanceTable.LeaveForm.EndDate.Value.Minute;
                var hourString1 = (hour1 < 10) ? ("0" + hour1) : ("" + hour1);
                var minString1 = (min1 < 10) ? ("0" + min1) : ("" + min1);
                var hourString2 = (hour2 < 10) ? ("0" + hour2) : ("" + hour2);
                var minString2 = (min2 < 10) ? ("0" + min2) : ("" + min2);

                ViewBag.editBeginDate = dateString1 + hourString1 + ':' + minString1;
                ViewBag.editEndDate = dateString2 + hourString2 + ':' + minString2;
                ViewBag.isEdit = "true";
                ViewBag.isRejectBtn = "true";
                ViewBag.isCanceledBtn = "false";
                ViewBag.isSendBtn = "false";
                ViewBag.isEditBtn = "true";
                ViewBag.isAcceptBtn = "true";
            }
            else if (processInstanceTable.StarterId == user.Id)
            {
                ViewBag.editBeginDate = processInstanceTable.LeaveForm.BeginDate;
                ViewBag.editEndDate = processInstanceTable.LeaveForm.EndDate;
                ViewBag.isEdit = "false";
                ViewBag.isRejectBtn = "false";
                ViewBag.isCanceledBtn = "true";
                ViewBag.isSendBtn = "false";
                ViewBag.isEditBtn = "false";
                ViewBag.isAcceptBtn = "false";
            }

            return View();
        }

        [HttpPost]
        public JsonResult EditRejectBtn(int processInstanceTablesId, int leaveFormId)
        {

            //不受理
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == processInstanceTablesId);
            var nextProcessNodeTableId = processInstanceTable.NextProcessNodeTableId;
            var processNodeTable1 = db.ProcessNodeTable.FirstOrDefault(x => x.Id == nextProcessNodeTableId);

            var processInstanceTableLog = new ProcessInstanceTableLog();
            processInstanceTableLog.Remarks = "不受理請假單";
            processInstanceTableLog.NodeSN = processNodeTable1.NodeSN;
            processInstanceTableLog.NodeName = processNodeTable1.NodeName;
            processInstanceTableLog.PITStatusId = 5; //不受理
            processInstanceTableLog.LeaveFormNo = processInstanceTable.LeaveFormNo;
            processInstanceTableLog.StarterId = processInstanceTable.StarterId;
            processInstanceTableLog.Starter = processInstanceTable.Starter;
            processInstanceTableLog.OperatorId = processInstanceTable.ToDoerId.Value;
            processInstanceTableLog.Operator = processInstanceTable.ToDoer;
            processInstanceTableLog.ToDoerId = processInstanceTable.StarterId;
            processInstanceTableLog.ToDoer = processInstanceTable.Starter;
            processInstanceTableLog.UpdateTime = DateTime.Now;
            processInstanceTableLog.LeaveFormId = processInstanceTable.LeaveFormId;
            processInstanceTableLog.ProcessNodeTableId = processNodeTable1.Id;
            processInstanceTableLog.FirstNodeSN = processInstanceTable.FirstNodeSN;
            processInstanceTableLog.FirstProcessNodeTableId = processInstanceTable.FirstProcessNodeTableId;
            processInstanceTableLog.NextNodeSN = processInstanceTable.FirstNodeSN;
            processInstanceTableLog.NextProcessNodeTableId = processInstanceTable.FirstProcessNodeTableId;
            processInstanceTableLog.ProcessInstanceTableId = processInstanceTablesId;

            db.ProcessInstanceTableLog.Add(processInstanceTableLog);
            db.SaveChanges();


            processInstanceTable.NodeSN = processNodeTable1.NodeSN;
            processInstanceTable.NodeName = processNodeTable1.NodeName;
            processInstanceTable.PITStatusId = 5; //不受理
            processInstanceTable.OperatorId = processInstanceTable.ToDoerId.Value;
            processInstanceTable.Operator = processInstanceTable.ToDoer;
            processInstanceTable.ToDoerId = processInstanceTable.StarterId;
            processInstanceTable.ToDoer = processInstanceTable.Starter;
            processInstanceTable.UpdateTime = DateTime.Now;
            processInstanceTable.Remarks = "不受理請假單";
            processInstanceTable.ProcessNodeTableId = processNodeTable1.Id;
            processInstanceTable.NextNodeSN = processInstanceTable.FirstNodeSN;
            processInstanceTable.NextProcessNodeTableId = processInstanceTable.FirstProcessNodeTableId;
            db.SaveChanges();

            return Json(new { message = "" });
        }

        [HttpPost]
        public JsonResult EditCanceledBtn(int processInstanceTablesId, int leaveFormId)
        {

            //撤銷請假單
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            string sIDNo = Session["sIDNo"].ToString();
            var applicationUser = db.ApplicationUser.FirstOrDefault(x => x.LogonId == sIDNo);
            var leaveForm = db.LeaveForm.FirstOrDefault(x => x.Id == leaveFormId);
            var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == processInstanceTablesId);

            leaveForm.LastModifierTime = DateTime.Now;
            leaveForm.LastModifierUserId = applicationUser.Id;
            leaveForm.IsDelete = true;
            db.SaveChanges();

            processInstanceTable.PITStatusId = 3; //撤銷
            processInstanceTable.UpdateTime = DateTime.Now;
            processInstanceTable.Remarks = "撤銷請假單";
            db.SaveChanges();


            var processInstanceTableLog = new ProcessInstanceTableLog();
            processInstanceTableLog.Remarks = "撤銷請假單";
            processInstanceTableLog.NodeSN = processInstanceTable.NodeSN;
            processInstanceTableLog.NodeName = processInstanceTable.NodeName;
            processInstanceTableLog.PITStatusId = 3; //撤銷
            processInstanceTableLog.LeaveFormNo = processInstanceTable.LeaveFormNo;
            processInstanceTableLog.StarterId = processInstanceTable.StarterId;
            processInstanceTableLog.Starter = processInstanceTable.Starter;
            processInstanceTableLog.OperatorId = processInstanceTable.OperatorId;
            processInstanceTableLog.Operator = processInstanceTable.Operator;
            processInstanceTable.ToDoerId = processInstanceTable.ToDoerId;
            processInstanceTable.ToDoer = processInstanceTable.ToDoer;
            processInstanceTableLog.UpdateTime = DateTime.Now;
            processInstanceTableLog.LeaveFormId = processInstanceTable.LeaveFormId;
            processInstanceTableLog.ProcessNodeTableId = processInstanceTable.ProcessNodeTableId;
            processInstanceTableLog.FirstNodeSN = processInstanceTable.FirstNodeSN;
            processInstanceTableLog.FirstProcessNodeTableId = processInstanceTable.FirstProcessNodeTableId;
            processInstanceTableLog.NextNodeSN = processInstanceTable.NextNodeSN;
            processInstanceTableLog.NextProcessNodeTableId = processInstanceTable.NextProcessNodeTableId;
            processInstanceTableLog.ProcessInstanceTableId = processInstanceTablesId;

            db.ProcessInstanceTableLog.Add(processInstanceTableLog);
            db.SaveChanges();


            return Json(new { message = "" });
        }

        [HttpPost]
        public JsonResult EditSendBtn(int processInstanceTablesId, int leaveFormId)
        {

            //重新送出請假單
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == processInstanceTablesId);
            var nextProcessNodeTableId = processInstanceTable.NextProcessNodeTableId;
            var processNodeTable1 = db.ProcessNodeTable.FirstOrDefault(x => x.Id == nextProcessNodeTableId);
            var nxtNodeSN1 = processNodeTable1.NextNodeSN;
            var processNodeTable2 = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nxtNodeSN1);

            var processInstanceTableLog = new ProcessInstanceTableLog();
            processInstanceTableLog.Remarks = "重新送出請假單";
            processInstanceTableLog.NodeSN = processNodeTable1.NodeSN;
            processInstanceTableLog.NodeName = processNodeTable1.NodeName;
            processInstanceTableLog.PITStatusId = 1; //已申請
            processInstanceTableLog.LeaveFormNo = processInstanceTable.LeaveFormNo;
            processInstanceTableLog.StarterId = processInstanceTable.StarterId;
            processInstanceTableLog.Starter = processInstanceTable.Starter;
            processInstanceTableLog.OperatorId = processInstanceTable.ToDoerId.Value;
            processInstanceTableLog.Operator = processInstanceTable.ToDoer;
            if (processNodeTable2.NodeName == "代理人")
            {
                var agent = processInstanceTable.LeaveForm.AgentLogonId;
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == agent);
                processInstanceTableLog.ToDoerId = applicationUser1.Id;
                processInstanceTableLog.ToDoer = applicationUser1.UserName;
            }
            else if (processNodeTable2.NodeName == "班導審核")
            {
                var sIDNo = processInstanceTable.LeaveForm.LogonId;
                var student = db.Student.FirstOrDefault(x => x.LogonId == sIDNo);
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == student.ClassGuideLogonId);
                processInstanceTableLog.ToDoerId = applicationUser1.Id;
                processInstanceTableLog.ToDoer = applicationUser1.UserName;
            }
            else
            {
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable2.JobTypeId);
                processInstanceTableLog.ToDoerId = applicationUser1.Id;
                processInstanceTableLog.ToDoer = applicationUser1.UserName;
            }
            processInstanceTableLog.UpdateTime = DateTime.Now;
            processInstanceTableLog.LeaveFormId = processInstanceTable.LeaveFormId;
            processInstanceTableLog.ProcessNodeTableId = processNodeTable1.Id;
            processInstanceTableLog.FirstNodeSN = processInstanceTable.FirstNodeSN;
            processInstanceTableLog.FirstProcessNodeTableId = processInstanceTable.FirstProcessNodeTableId;
            processInstanceTableLog.NextNodeSN = processNodeTable2.NodeSN;
            processInstanceTableLog.NextProcessNodeTableId = processNodeTable2.Id;
            processInstanceTableLog.ProcessInstanceTableId = processInstanceTablesId;

            db.ProcessInstanceTableLog.Add(processInstanceTableLog);
            db.SaveChanges();


            processInstanceTable.NodeSN = processNodeTable1.NodeSN;
            processInstanceTable.NodeName = processNodeTable1.NodeName;
            processInstanceTable.PITStatusId = 1; //已申請
            processInstanceTable.OperatorId = processInstanceTable.ToDoerId.Value;
            processInstanceTable.Operator = processInstanceTable.ToDoer;
            if (processNodeTable2.NodeName == "代理人")
            {
                var agent = processInstanceTable.LeaveForm.AgentLogonId;
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == agent);
                processInstanceTable.ToDoerId = applicationUser1.Id;
                processInstanceTable.ToDoer = applicationUser1.UserName;
            }
            else if (processNodeTable2.NodeName == "班導審核")
            {
                var sIDNo = processInstanceTable.LeaveForm.LogonId;
                var student = db.Student.FirstOrDefault(x => x.LogonId == sIDNo);
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == student.ClassGuideLogonId);
                processInstanceTable.ToDoerId = applicationUser1.Id;
                processInstanceTable.ToDoer = applicationUser1.UserName;
            }
            else
            {
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable2.JobTypeId);
                processInstanceTable.ToDoerId = applicationUser1.Id;
                processInstanceTable.ToDoer = applicationUser1.UserName;
            }
            processInstanceTable.UpdateTime = DateTime.Now;
            processInstanceTable.Remarks = "重新送出請假單";
            processInstanceTable.ProcessNodeTableId = processNodeTable1.Id;
            processInstanceTable.NextNodeSN = processNodeTable2.NodeSN;
            processInstanceTable.NextProcessNodeTableId = processNodeTable2.Id;
            db.SaveChanges();


            return Json(new { message = "" });
        }

        [HttpPost]
        public JsonResult EditLeaveFormSave(EditLeaveFormDto input, IEnumerable<HttpPostedFileBase> dataFile, List<int> dataFilesDeleteList)
        {

            //撤銷請假單
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            string sIDNo = Session["sIDNo"].ToString();
            var applicationUser = db.ApplicationUser.FirstOrDefault(x => x.LogonId == sIDNo);
            var leaveForm = db.LeaveForm.FirstOrDefault(x => x.Id == input.LeaveFormId);
            var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == input.ProcessInstanceTablesId);
            var typeOfLeave = db.TypeOfLeave.FirstOrDefault(x => x.TypeOfLeaveName == input.TypeOfLeave);

            leaveForm.TypeOfLeaveId = typeOfLeave.Id;
            if (input.Agent != null)
            {
                if (input.Agent != "null")
                {
                    int agentInt = input.Agent.IndexOf("-");
                    var agent = input.Agent.Substring(agentInt + 1);
                    leaveForm.AgentLogonId = agent;
                }

            }
            leaveForm.Reason = input.EditReason;
            leaveForm.TimeOff = input.Total;

            var beginDate1 = input.EditBeginDate.Replace("-", "/");//利用regular expression  將'-' 代換成 '/'
            var beginDate2 = beginDate1.Replace("T", " ");
            var endDate1 = input.EditEndDate.Replace("-", "/");//利用regular expression  將'-' 代換成 '/'
            var endDate2 = endDate1.Replace("T", " ");
            var addBeginDate = Convert.ToDateTime(beginDate2);
            var addEndDate = Convert.ToDateTime(endDate2);
            leaveForm.BeginDate = addBeginDate;
            leaveForm.EndDate = addEndDate;
            leaveForm.LastModifierTime = DateTime.Now;
            leaveForm.LastModifierUserId = applicationUser.Id;
            leaveForm.Remarks = "更新假單";
            db.SaveChanges();

            if (dataFilesDeleteList != null)
            {
                if (dataFilesDeleteList.Count() > 0)
                {
                    //刪除已存在資料庫的檔案
                    foreach (var d in dataFilesDeleteList)
                    {
                        var certifiedDoc = db.CertifiedDoc.FirstOrDefault(x => x.Id == d);
                        var certifiedDocesId = d;
                        var leaveFormCertifiedDoc = db.LeaveFormCertifiedDoc.FirstOrDefault(x => x.Id == certifiedDocesId);

                        string Path = HostingEnvironment.MapPath("/ProofOfLeaveForm/" + certifiedDoc.FileName);

                        db.LeaveFormCertifiedDoc.Remove(leaveFormCertifiedDoc);
                        db.SaveChanges();

                        db.CertifiedDoc.Remove(certifiedDoc);
                        db.SaveChanges();

                        if (System.IO.File.Exists(Path))
                        {
                            System.IO.File.Delete(Path);
                        }
                    }

                }
            }


            if (dataFile.Count() != 0)
            {
                //檔案資訊存進資料庫
                foreach (var AuploadFile in dataFile)
                {
                    string FileName = System.IO.Path.GetFileName(AuploadFile.FileName);
                    string Path = HostingEnvironment.MapPath("/ProofOfLeaveForm/" + FileName);

                    CertifiedDoc certifiedDoc = new CertifiedDoc
                    {
                        FileName = FileName,
                        FileSize = AuploadFile.ContentLength,
                        CreateDate = DateTime.Now,
                    };
                    db.CertifiedDoc.Add(certifiedDoc);
                    db.SaveChanges();
                    int certifiedDocId = db.CertifiedDoc.OrderByDescending(x => x.Id).ToList()[0].Id;

                    LeaveFormCertifiedDoc leaveFormCertifiedDoc = new LeaveFormCertifiedDoc
                    {
                        LeaveFormId = input.LeaveFormId,
                        CertifiedDocId = certifiedDocId,
                    };
                    db.LeaveFormCertifiedDoc.Add(leaveFormCertifiedDoc);
                    db.SaveChanges();

                    AuploadFile.SaveAs(Path);
                }
            }

            return Json(new { message = string.Format("請假單已修改成功~") });
        }

        [HttpPost]
        public JsonResult EditAcceptBtn(int processInstanceTablesId, int leaveFormId)
        {

            //受理請假單
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == processInstanceTablesId);
            var timeOff = processInstanceTable.LeaveForm.TimeOff / 8;
            var nextProcessNodeTableId = processInstanceTable.NextProcessNodeTableId;
            var processNodeTable1 = db.ProcessNodeTable.FirstOrDefault(x => x.Id == nextProcessNodeTableId);
            var nxtNodeSN1 = processNodeTable1.NextNodeSN;
            var processNodeTable2 = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nxtNodeSN1);

            var processInstanceTableLog = new ProcessInstanceTableLog();
            processInstanceTableLog.Remarks = "受理請假單";
            processInstanceTableLog.NodeSN = processNodeTable1.NodeSN;
            processInstanceTableLog.NodeName = processNodeTable1.NodeName;
            processInstanceTableLog.LeaveFormNo = processInstanceTable.LeaveFormNo;
            processInstanceTableLog.StarterId = processInstanceTable.StarterId;
            processInstanceTableLog.Starter = processInstanceTable.Starter;
            processInstanceTableLog.OperatorId = processInstanceTable.ToDoerId.Value;
            processInstanceTableLog.Operator = processInstanceTable.ToDoer;
            processInstanceTableLog.NextNodeSN = processNodeTable2.NodeSN;
            processInstanceTableLog.NextProcessNodeTableId = processNodeTable2.Id;

            if (processNodeTable2.NodeName == "結案")
            {
                processInstanceTableLog.PITStatusId = 4; //已同意
            }
            else if (processNodeTable2.MinLeaveNum > 3)
            {
                //判斷請超過3天
                processInstanceTableLog.PITStatusId = 2; //已受理

                if (timeOff > 3)
                {
                    //請超過3天
                    var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable2.JobTypeId);
                    processInstanceTableLog.ToDoerId = applicationUser1.Id;
                    processInstanceTableLog.ToDoer = applicationUser1.UserName;
                }
                else
                {
                    //未超過3天
                    var nextNodeSN2 = processNodeTable2.NextNodeSN;
                    //未超過三天不須給校長簽核,所以給下一位做簽核
                    var processNodeTable3 = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nextNodeSN2);
                    var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable3.JobTypeId);
                    processInstanceTableLog.ToDoerId = applicationUser1.Id;
                    processInstanceTableLog.ToDoer = applicationUser1.UserName;
                    processInstanceTableLog.NextNodeSN = processNodeTable3.NodeSN;
                    processInstanceTableLog.NextProcessNodeTableId = processNodeTable3.Id;
                }


            }
            else
            {
                processInstanceTableLog.PITStatusId = 2; //已受理

                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable2.JobTypeId);
                processInstanceTableLog.ToDoerId = applicationUser1.Id;
                processInstanceTableLog.ToDoer = applicationUser1.UserName;
            }
            processInstanceTableLog.UpdateTime = DateTime.Now;
            processInstanceTableLog.LeaveFormId = processInstanceTable.LeaveFormId;
            processInstanceTableLog.ProcessNodeTableId = processNodeTable1.Id;
            processInstanceTableLog.FirstNodeSN = processInstanceTable.FirstNodeSN;
            processInstanceTableLog.FirstProcessNodeTableId = processInstanceTable.FirstProcessNodeTableId;
            processInstanceTableLog.ProcessInstanceTableId = processInstanceTablesId;

            db.ProcessInstanceTableLog.Add(processInstanceTableLog);
            db.SaveChanges();


            processInstanceTable.NodeSN = processNodeTable1.NodeSN;
            processInstanceTable.NodeName = processNodeTable1.NodeName;
            processInstanceTable.OperatorId = processInstanceTable.ToDoerId.Value;
            processInstanceTable.Operator = processInstanceTable.ToDoer;
            processInstanceTable.NextNodeSN = processNodeTable2.NodeSN;
            processInstanceTable.NextProcessNodeTableId = processNodeTable2.Id;

            if (processNodeTable2.NodeName == "結案")
            {
                processInstanceTable.PITStatusId = 4; //已同意
                processInstanceTable.ToDoerId = null;
                processInstanceTable.ToDoer = null;
            }
            else if (processNodeTable2.MinLeaveNum > 3)
            {
                //判斷請超過3天
                processInstanceTable.PITStatusId = 2; //已受理

                if (timeOff > 3)
                {
                    //請超過3天
                    var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable2.JobTypeId);
                    processInstanceTable.ToDoerId = applicationUser1.Id;
                    processInstanceTable.ToDoer = applicationUser1.UserName;
                }
                else
                {
                    //未超過3天
                    var nextNodeSN2 = processNodeTable2.NextNodeSN;
                    //未超過三天不須給校長簽核,所以給下一位做簽核
                    var processNodeTable3 = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nextNodeSN2);
                    var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable3.JobTypeId);
                    processInstanceTable.ToDoerId = applicationUser1.Id;
                    processInstanceTable.ToDoer = applicationUser1.UserName;
                    processInstanceTable.NextNodeSN = processNodeTable3.NodeSN;
                    processInstanceTable.NextProcessNodeTableId = processNodeTable3.Id;
                }


            }
            else
            {
                processInstanceTable.PITStatusId = 2; //已受理

                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable2.JobTypeId);
                processInstanceTable.ToDoerId = applicationUser1.Id;
                processInstanceTable.ToDoer = applicationUser1.UserName;
            }
            processInstanceTable.UpdateTime = DateTime.Now;
            processInstanceTable.Remarks = "受理請假單";
            processInstanceTable.ProcessNodeTableId = processNodeTable1.Id;
            db.SaveChanges();

            return Json(new { message = "" });
        }

        public ActionResult AddLeaveFormByEmployee()
        {
            if (Session["sIDNo"] == null)
            {
                return RedirectToAction("../Home/Index");
            }

            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            string sIDNo = Session["sIDNo"].ToString();

            var applicationUser = db.ApplicationUser.FirstOrDefault(x => x.LogonId == sIDNo);

            //寫入多筆代理人
            var agent = "";
            List<string> agentList = new List<string>();
            var employees = db.Employee.Where(x => x.IsActive == true && x.LogonId != sIDNo).ToList();
            foreach (var employee in employees)
            {
                var e = employee.ApplicationUser.JobType.SchoolDepartment.Department + "-" + employee.LogonId;
                agentList.Add(e);
            }
            agent = agentList[0];

            //簽核流程
            var nodeSN = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NodeSN;
            var numberOfTimes = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NumberOfTimes;
            string nodeSNNext = nodeSN;
            string process = "";
            for (int i = 1; i <= numberOfTimes; i++)
            {
                var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nodeSNNext);

                if (processNodeTable.MinLeaveNum == 4)
                {
                    //超過3天假
                    process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:未受理</a></li> ";
                }
                else if (processNodeTable.NodeOrder == 1)
                {
                    process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未申請</a></li> ";
                }
                else if (processNodeTable.NodeName == "結案")
                {
                    process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未同意</a></li> ";
                }
                else if (processNodeTable.NodeOrder != 1)
                {
                    process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未受理</a></li> ";
                }


                if (processNodeTable.NodeName != "結案")
                {
                    nodeSNNext = processNodeTable.NextNodeSN;
                }

                if (processNodeTable.NodeOrder == 2 && processNodeTable.NodeName != "代理人")
                {
                    agent = "";
                }

            }

            //任職幾年
            var totalYear = (int)(DateTime.Now.Date - applicationUser.EnrollmentDate.Value.Date).TotalDays / 365;
            //任職幾天
            var date3 = (DateTime.Now.Date - applicationUser.EnrollmentDate.Value.Date).TotalDays - (365 * totalYear);
            //顯示請假狀態(第一筆:特休假,第二筆:事假,第三筆:生理假,每位員工只會有三筆資料,如果已有資料則會修改資料)
            var getLeaveStatusFormByEmployees = db.Database.SqlQuery<GetLeaveStatusFormByEmployees>(@"execute GetLeaveStatusFormByEmployees_InsertAndUpdate '" + sIDNo + "' ");

            //生理假規則
            var leaveForms = db.LeaveForm.Where(x => x.LogonId == sIDNo && x.IsDelete == false && x.TypeOfLeaveId == 12 && x.BeginDate.Value.Year == DateTime.Now.Year && x.BeginDate.Value.Month == DateTime.Now.Month);

            ViewBag.userName = applicationUser.UserName + " " + "(" + applicationUser.LogonId + ")";
            ViewBag.firstTime = applicationUser.EnrollmentDate.Value.ToString("yyyy-MM-dd") + "(任職" + totalYear + "年" + date3 + "天" + ")";
            ViewBag.specialVacation = getLeaveStatusFormByEmployees.ToList()[0].LeaveRulesString;
            ViewBag.personalLeave = getLeaveStatusFormByEmployees.ToList()[1].LeaveRulesString;
            ViewBag.physiologicalLeave = getLeaveStatusFormByEmployees.ToList()[2].LeaveRulesString;
            ViewBag.specialVacationNum = getLeaveStatusFormByEmployees.ToList()[0].RemainingLeaveHR;
            ViewBag.personalLeaveNum = getLeaveStatusFormByEmployees.ToList()[1].RemainingLeaveHR;
            ViewBag.physiologicalLeaveNum = getLeaveStatusFormByEmployees.ToList()[2].RemainingLeaveHR;
            ViewBag.agent = agent;
            ViewBag.agents = agentList;
            ViewBag.process = process;
            ViewBag.physiologicalLeaveNotice = (leaveForms.Count() > 0) ? "生理假這個月已使用" : "生理假這個月尚未使用";


            return View();
        }

        public ActionResult AddLeaveFormByStudent()
        {
            if (Session["sIDNo"] == null)
            {
                return RedirectToAction("../Home/Index");
            }

            LeaveFormSchoolContext db = new LeaveFormSchoolContext();
            string sIDNo = Session["sIDNo"].ToString();

            var applicationUser = db.ApplicationUser.FirstOrDefault(x => x.LogonId == sIDNo);

            //簽核流程
            var nodeSN = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NodeSN;
            var numberOfTimes = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1).NumberOfTimes;
            string nodeSNNext = nodeSN;
            string process = "";
            for (int i = 1; i <= numberOfTimes; i++)
            {
                var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == nodeSNNext);

                if (processNodeTable.MinLeaveNum == 4)
                {
                    //超過3天假
                    process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + "<span style=\"color: red\">(超過3天假)</span>:未受理</a></li> ";
                }
                else if (processNodeTable.NodeOrder == 1)
                {
                    process += "<li class=\"current\"><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未申請</a></li> ";
                }
                else if (processNodeTable.NodeName == "結案")
                {
                    process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未同意</a></li> ";
                }
                else if (processNodeTable.NodeOrder != 1)
                {
                    process += "<li><a href=\"javascript: void(0); \">" + i + ". " + processNodeTable.NodeName + ":未受理</a></li> ";
                }


                if (processNodeTable.NodeName != "結案")
                {
                    nodeSNNext = processNodeTable.NextNodeSN;
                }

            }

            //生理假規則
            var leaveForms = db.LeaveForm.Where(x => x.LogonId == sIDNo && x.IsDelete == false && x.TypeOfLeaveId == 12 && x.BeginDate.Value.Year == DateTime.Now.Year && x.BeginDate.Value.Month == DateTime.Now.Month);

            ViewBag.userName = applicationUser.UserName + " " + "(" + applicationUser.LogonId + ")";
            ViewBag.physiologicalLeave = (leaveForms.Count() > 0) ? "這個月已使用" : "這個月尚未使用";
            ViewBag.process = process;

            return View();
        }

        public ActionResult LeaveRulesByEmployee()
        {
            return View();
        }

        public ActionResult LeaveRulesByStudent()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IsUsePhysiologicalLeave(string name, string beginDate, int processInstanceTablesId)
        {
            try
            {
                LeaveFormSchoolContext db = new LeaveFormSchoolContext();
                var beginDate1 = beginDate.Replace("-", "/");//利用regular expression  將'-' 代換成 '/'
                var beginDate2 = beginDate1.Replace("T", " ");
                var BeginDate = Convert.ToDateTime(beginDate2);

                if (name == "add")
                {
                    string sIDNo = Session["sIDNo"].ToString();

                    //生理假規則
                    var leaveForms = db.LeaveForm.Where(x => x.LogonId == sIDNo && x.IsDelete == false && x.TypeOfLeaveId == 12 && x.BeginDate.Value.Year == BeginDate.Year && x.BeginDate.Value.Month == BeginDate.Month);
                    if (leaveForms.Count() > 0) { throw new Exception("您的生理假已超過您有的天數,請再做確認!!!"); }
                }
                else if (name == "edit")
                {
                    var processInstanceTable = db.ProcessInstanceTable.FirstOrDefault(x => x.Id == processInstanceTablesId);
                    var leaveFormId = processInstanceTable.LeaveFormId;
                    var sIDNo = processInstanceTable.LeaveForm.LogonId;


                    //生理假規則
                    var leaveFormsById = db.LeaveForm.Where(x => x.Id != leaveFormId && x.LogonId == sIDNo && x.IsDelete == false && x.TypeOfLeaveId == 12 && x.BeginDate.Value.Year == BeginDate.Year && x.BeginDate.Value.Month == BeginDate.Month);

                    if (leaveFormsById.Count() > 0) { throw new Exception("您的生理假已超過您有的天數,請再做確認!!!"); }
                }

                return Json(new { message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, error = false });
            }
        }

        [HttpPost]
        public JsonResult IsDataFileExist(string[] fileNames)
        {
            try
            {
                string strFileName = "";
                foreach (var fileName in fileNames)
                {
                    LeaveFormSchoolContext db = new LeaveFormSchoolContext();
                    var GetByFileName = db.CertifiedDoc.Where(x => x.FileName == fileName).Count() == 0 ? false : true;
                    if (GetByFileName)
                    {
                        strFileName += fileName + ", ";

                    }
                }
                if (strFileName != "")
                {
                    throw new Exception("檔名相同: " + strFileName.Substring(0, strFileName.Length - 2) + " 請自動加檔名順位,讓檔名不要有衝突!");
                }


                return Json(new { message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, error = false });
            }
        }

        [HttpPost]
        public JsonResult AddLeaveFormSave(AddLeaveFormDto input, IEnumerable<HttpPostedFileBase> dataFile)
        {
            string sIDNo = Session["sIDNo"].ToString();
            AddLeaveFormServices.AddLeaveFormSave(input, dataFile, sIDNo);

            return Json(new { message = string.Format("請假單已成功申請~") });
        }


    }
}