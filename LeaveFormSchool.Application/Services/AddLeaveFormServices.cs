using LeaveFormSchool.Application.ViewModels;
using LeaveFormSchool.Core.DataModels;
using LeaveFormSchool.EntityFramework.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace LeaveFormSchool.Application.Services
{
    public class AddLeaveFormServices
    {

        public static void AddLeaveFormSave(AddLeaveFormDto input, IEnumerable<HttpPostedFileBase> dataFile, string sIDNo)
        {
            LeaveFormSchoolContext db = new LeaveFormSchoolContext();

            var applicationUser = db.ApplicationUser.FirstOrDefault(x => x.LogonId == sIDNo);
            var typeOfLeave = db.TypeOfLeave.FirstOrDefault(x => x.TypeOfLeaveName == input.TypeOfLeave);

            var leaveForm = new LeaveForm();
            DateTime datetime = DateTime.Now;
            var dayNow =datetime.ToString("yyyyMMdd");
            var leaveFormCount = db.LeaveForm.Count();
            var leaveFormNo = "A-" + dayNow + "-" + leaveFormCount; //ex: A-20210215-1
            leaveForm.LeaveFormNo = leaveFormNo;
            leaveForm.ApplicantName = applicationUser.UserName;
            leaveForm.LogonId = applicationUser.LogonId;
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
            leaveForm.Reason = input.AddReason;
            leaveForm.TimeOff = input.Total;

            var beginDate1= input.AddBeginDate.Replace("-", "/");//利用regular expression  將'-' 代換成 '/'
            var beginDate2 = beginDate1.Replace("T", " ");
            var endDate1 = input.AddEndDate.Replace("-", "/");//利用regular expression  將'-' 代換成 '/'
            var endDate2 = endDate1.Replace("T", " ");
            var addBeginDate = Convert.ToDateTime(beginDate2);
            var addEndDate = Convert.ToDateTime(endDate2);
            leaveForm.BeginDate = addBeginDate;
            leaveForm.EndDate = addEndDate;
            leaveForm.CreateTime = DateTime.Now;
            leaveForm.CreatedById = applicationUser.Id;
            leaveForm.IsDelete = false;
            leaveForm.ApplicationUserId = applicationUser.Id;

            db.LeaveForm.Add(leaveForm);
            db.SaveChanges();
            int leaveFormId = db.LeaveForm.OrderByDescending(x => x.Id).ToList()[0].Id;

            var processNodeTable = db.ProcessNodeTable.FirstOrDefault(x => x.JobTypeId == applicationUser.JobTypeId && x.NodeOrder == 1);

            var processInstanceTable = new ProcessInstanceTable();
            processInstanceTable.NodeSN = processNodeTable.NodeSN;
            processInstanceTable.NodeName = processNodeTable.NodeName;
            processInstanceTable.PITStatusId = 1; //已申請
            processInstanceTable.LeaveFormNo = leaveFormNo;
            processInstanceTable.StarterId = applicationUser.Id;
            processInstanceTable.Starter = applicationUser.UserName;
            processInstanceTable.OperatorId = applicationUser.Id;
            processInstanceTable.Operator = applicationUser.UserName;

            var processNodeTable1 = db.ProcessNodeTable.FirstOrDefault(x => x.NodeSN == processNodeTable.NextNodeSN);
            if (processNodeTable1.NodeName == "代理人")
            {
                int agentInt = input.Agent.IndexOf("-");
                var agent = input.Agent.Substring(agentInt + 1);
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == agent);
                processInstanceTable.ToDoerId = applicationUser1.Id;
                processInstanceTable.ToDoer = applicationUser1.UserName;
            }
            else if (processNodeTable1.NodeName == "班導審核")
            {
                var student = db.Student.FirstOrDefault(x => x.LogonId == sIDNo);
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == student.ClassGuideLogonId);
                processInstanceTable.ToDoerId = applicationUser1.Id;
                processInstanceTable.ToDoer = applicationUser1.UserName;
            }
            else
            {
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable1.JobTypeId);
                processInstanceTable.ToDoerId = applicationUser1.Id;
                processInstanceTable.ToDoer = applicationUser1.UserName;
            }

            processInstanceTable.FirstNodeSN = processNodeTable.NodeSN;
            processInstanceTable.FirstProcessNodeTableId = processNodeTable.Id;
            processInstanceTable.NextNodeSN = processNodeTable1.NodeSN;
            processInstanceTable.NextProcessNodeTableId = processNodeTable1.Id;
            processInstanceTable.UpdateTime = DateTime.Now;
            processInstanceTable.LeaveFormId = leaveFormId;
            processInstanceTable.ProcessNodeTableId = processNodeTable.Id;

            db.ProcessInstanceTable.Add(processInstanceTable);
            db.SaveChanges();
            int processInstanceTableId = db.ProcessInstanceTable.OrderByDescending(x => x.Id).ToList()[0].Id;


            var processInstanceTableLog = new ProcessInstanceTableLog();
            processInstanceTableLog.Remarks = "申請請假單";
            processInstanceTableLog.NodeSN = processNodeTable.NodeSN;
            processInstanceTableLog.NodeName = processNodeTable.NodeName;
            processInstanceTableLog.PITStatusId = 1; //已申請
            processInstanceTableLog.LeaveFormNo = leaveFormNo;
            processInstanceTableLog.StarterId = applicationUser.Id;
            processInstanceTableLog.Starter = applicationUser.UserName;
            processInstanceTableLog.OperatorId = applicationUser.Id;
            processInstanceTableLog.Operator = applicationUser.UserName;
            
            if (processNodeTable1.NodeName == "代理人")
            {
                int agentInt = input.Agent.IndexOf("-");
                var agent = input.Agent.Substring(agentInt + 1);
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == agent);
                processInstanceTableLog.ToDoerId = applicationUser1.Id;
                processInstanceTableLog.ToDoer = applicationUser1.UserName;
            }
            else if (processNodeTable1.NodeName == "班導審核")
            {
                var student = db.Student.FirstOrDefault(x => x.LogonId == sIDNo);
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.LogonId == student.ClassGuideLogonId);
                processInstanceTableLog.ToDoerId = applicationUser1.Id;
                processInstanceTableLog.ToDoer = applicationUser1.UserName;
            }
            else
            {
                var applicationUser1 = db.ApplicationUser.FirstOrDefault(x => x.JobTypeId == processNodeTable1.JobTypeId);
                processInstanceTableLog.ToDoerId = applicationUser1.Id;
                processInstanceTableLog.ToDoer = applicationUser1.UserName;
            }

            processInstanceTableLog.FirstNodeSN = processNodeTable.NodeSN;
            processInstanceTableLog.FirstProcessNodeTableId = processNodeTable.Id;
            processInstanceTableLog.NextNodeSN = processNodeTable1.NodeSN;
            processInstanceTableLog.NextProcessNodeTableId = processNodeTable1.Id;
            processInstanceTableLog.UpdateTime = DateTime.Now;
            processInstanceTableLog.LeaveFormId = leaveFormId;
            processInstanceTableLog.ProcessNodeTableId = processNodeTable.Id;
            processInstanceTableLog.ProcessInstanceTableId = processInstanceTableId;

            db.ProcessInstanceTableLog.Add(processInstanceTableLog);
            db.SaveChanges();



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
                        LeaveFormId = leaveFormId,
                        CertifiedDocId = certifiedDocId,
                    };
                    db.LeaveFormCertifiedDoc.Add(leaveFormCertifiedDoc);
                    db.SaveChanges();

                    AuploadFile.SaveAs(Path);
                }
            }
            

        }


    }
}
