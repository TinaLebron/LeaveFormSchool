using LeaveFormSchool.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Application.Services
{
    public class CommonToolServices
    {
        /// <summary>
        /// 自訂分頁物件
        /// </summary>
        /// <param name="currPage">所在頁碼</param>
        /// <param name="cntPage">顯示頁碼maxValue(每頁顯示資料量)</param>
        /// <param name="totPage">資料總頁數</param>
        /// <returns></returns>
        public static PageData GetDisplayPages(int currPage, int cntPage, int totPage)
        {
            PageData pgdata = new PageData();

            // 總頁數除以每頁最大數量=>取得有幾個分頁(有餘數加1)
            int ppSize = totPage / cntPage; 
            if (totPage % cntPage > 0)
                ppSize++;

            int currppSize = 1;
            if (currPage % cntPage != 0)
                currppSize = (currPage / cntPage) + 1;
            else
                currppSize = (currPage / cntPage);
            //判斷是否顯示省略符號            
            int pStart = 1;
            if (currPage % cntPage != 0)
                pStart = ((currPage / cntPage) * cntPage + 1);
            else
                pStart = ((currPage - 1) / cntPage) * cntPage + 1;
            int pEnd = pStart + (cntPage - 1);
            if (pEnd > totPage)
                pEnd = totPage;
            if (currppSize > 1)
            {
                pgdata.DisplayLeftEllipsesZone = true;
                pgdata.LeftEllipsIndex = (pStart - 1).ToString();
            }
            if (currppSize < ppSize)
            {
                pgdata.DisplayRightEllipsesZone = true;
                pgdata.RightEllipsIndex = (pEnd + 1).ToString();
            }
            //畫面上顯示之頁碼
            for (int i = pStart; i <= pEnd; i++)
            {
                pgdata.DisplayPageZone.Add(i.ToString());
            }

            //首頁末頁
            if (currPage == 1)
            {
                if (totPage > 1)
                    pgdata.EnableRight = true;
            }
            else
            {
                if (currPage == totPage)
                    pgdata.EnableLeft = true;
                else
                {
                    pgdata.EnableLeft = true;
                    pgdata.EnableRight = true;
                }
            }
            pgdata.TotalPage = totPage.ToString();
            pgdata.CurrentPage = currPage.ToString();

            return pgdata;
        }
        
    }
}
