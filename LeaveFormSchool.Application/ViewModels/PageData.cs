using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.Application.ViewModels
{
    public class PageData
    {
        //pager model
        //往前
        public bool EnableLeft { get; set; }
        //往後
        public bool EnableRight { get; set; }
        //省略符號(前)
        public bool DisplayLeftEllipsesZone { get; set; }
        //省略符號(後)
        public bool DisplayRightEllipsesZone { get; set; }
        //省略符號index(前)
        public string LeftEllipsIndex { get; set; }
        //省略符號index(後)
        public string RightEllipsIndex { get; set; }
        //顯示頁碼
        public List<string> DisplayPageZone { get; set; }
        //總頁數
        public string TotalPage { get; set; }
        //現在頁數
        public string CurrentPage { get; set; }

        public PageData()
        {
            this.EnableLeft = false;
            this.EnableRight = false;
            this.DisplayLeftEllipsesZone = false;
            this.DisplayRightEllipsesZone = false;
            this.LeftEllipsIndex = "1";
            this.RightEllipsIndex = "1";
            this.TotalPage = "1";
            this.CurrentPage = "1";
            this.DisplayPageZone = new List<string>();
        }
    }
}
