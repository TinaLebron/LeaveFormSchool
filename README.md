# LeaveFormSchool

• 目的: 主要是想練習vue.js,於是決定寫請假單來做練習

• 使用工具:
  ASP.NET MVC, vue.js, Ajax, Entity Framework 6 Code First, MS sql, jQuery, bootstrap, css,stored procedure

• 內容: 

  1. 學校請假系統為主軸
 
     人員包含:校長,副校長,會計師,人事,學務處,教務處,行政人員,老師,學生
     
     學校規模: 
     
        校長室
        
        副校長室
        
        人事處(主任,人員)
        
        會計處(主任,人員)
        
        教務處(主任,人員)

        資訊處(主任,工程師)

        學務處 => 
        
        資訊設計學院->資訊工程學系->主任->導師
        
        資訊設計學院->資管工程學系->主任->導師
        
        教育學院->英美語文學系->主任->導師

        學生 =>
        
        資訊設計學院->資訊工程學系->學生
        
        資訊設計學院->資管工程學系->學生 
        
        教育學院->英美語文學系->學生
        
     
  
  2. 依照不同身份有不同的請假申請流程
     
       流程節點表: 
       
          校長:

          申請人->人事(主任)->結束

          副校長:

          申請人->校長->人事(主任)->結束

          主任:

          申請人->代理人->人事(主任)->結束

          申請人->代理人->校長->人事->結束 (請超過3天)

          一般:

          申請人->代理人->主任->人事(主任)->結束

          申請人->代理人->主任->校長->人事(主任)->結束 (請超過3天)

          學生:

          申請人->班導->人事(主任)->結束

          申請人->班導->主任->人事(主任)->結束 (請超過3天)
          
  3. 請假規則
       
        以員工
        
        特休假:
        
        a. 6個月以上1年未滿者，3日。 b. 1年以上2年未滿者，7日。

        c. 2年以上3年未滿者，10日。 d. 3年以上5年未滿者，每年14日。

        e. 5年以上10年未滿者，每年15日。

        f. 10年以上者，每一年加給1日，加至30日為止。
        
        事假: 一年內合計不得超過十四日,超過14天。
        
        生理假: 每個月可以有1天的生理假，這樣的生理假只要1年內不超過3天，是不用計入病假計算的，超過3天的話就與病假一起列入計算。
        
        以學生
        
        生理假: 每個月可以有1天的生理假。
 
 
• 畫面呈現: 

   ## LogIn
   
   <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-login.PNG" width="650" />
   
   ## Main

  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveForm1.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveForm2.PNG" width="800" />

  | Option | Description |
  | ------ | ----------- |
  |   查詢條件    | 進行中,表示自己的假單流程尚未跑完,或是別人的請假單需要你做簽核的動作. 已完成,表示假單已同意. 已撤銷,自己把假單取消,撤銷後無法再修改,只能請新的假單. |
  |   假單清單    | 顯示請假單編號,請假類型,請假開始時間,請假結束時間,假單情況. |

  ## Add LeaveForm

  員工
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-AddLeaveFormByEmployee.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-AddLeaveFormByEmployee2.PNG" width="800" />
  <br/><br/>
  學生
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-AddLeaveFormByStudent.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-AddLeaveFormByStudent2.PNG" width="800" />
  

  | Option | Description |
  | ------ | ----------- |
  |  送單按鈕  | 顯示錯誤視窗: 1.員工與學生超出請假規則的次數.2.除了上傳附件以外,其他資料不為空. 請假單送出後會依照流程節點表作簽核. |
   
  ## LeaveForm

  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveFormByEmployee1.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveFormByEmployee2.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveFormByEmployee3.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveFormByEmployee4.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveFormByEmployee5.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveFormByEmployee6.PNG" width="800" />
  <br/>
  <img src="https://github.com/TinaLebron/LeaveFormSchool/blob/master/LeaveFormSchool/Images/github-LeaveFormByEmployee7.PNG" width="800" />

  | Option | Description |
  | ------ | ----------- |
  |  撤銷按鈕   | 只能撤銷自己的請假單,被撤銷的請假單就不能再使用,請重新在寫新的請假單. |
  |  受理按鈕  | 如果你是代理人或是主管階級必須由你來簽核,按下受理按鈕表示你同意這張單子. |
  |  更新按鈕   | 代理人或是主管看到你的單子有填寫錯誤的地方,他們可以幫你做修改. |
  |  送單按鈕   | 代理人或是主管不同意你的單子,所以必須修改後重新送單. |
  |  不受理按鈕   | 如果你是代理人或是主管階級必須由你來簽核,按下不受理按鈕表示你不同意這張單子,不同意單子會回到申請人手上,然後申請人必須修改後再重新送單. |
   
   
   
       
       
       
       
       
       
       
       
   
