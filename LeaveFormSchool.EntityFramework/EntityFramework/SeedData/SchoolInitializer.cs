using LeaveFormSchool.Core.DataModels;
using LeaveFormSchool.Core.Enums;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveFormSchool.EntityFramework.EntityFramework.SeedData
{
    public class SchoolInitializer
    {
        private readonly LeaveFormSchoolContext _context;

        public SchoolInitializer(LeaveFormSchoolContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateSchoolInitializer();
        }

        private void CreateSchoolInitializer()
        {
            var schoolDepartment = new List<SchoolDepartment>
            {
            new SchoolDepartment{Department="校長室"},
            new SchoolDepartment{Department="副校長室"},
            new SchoolDepartment{Department="人事處"},
            new SchoolDepartment{Department="會計處"},
            new SchoolDepartment{Department="學務處"},
            new SchoolDepartment{Department="教務處"},
            new SchoolDepartment{Department="資訊處"},
            };
            schoolDepartment.ForEach(s => _context.SchoolDepartment.Add(s));
            _context.SaveChanges();

            var schoolCollege = new List<SchoolCollege>
            {
            new SchoolCollege{College="資訊設計學院",Department="資訊工程學系"},
            new SchoolCollege{College="資訊設計學院",Department="資管工程學系"},
            new SchoolCollege{College="教育學院",Department="英美語文學系"},
            };
            schoolCollege.ForEach(s => _context.SchoolCollege.Add(s));
            _context.SaveChanges();

            var jobType = new List<JobType>
            {
            //校長
            new JobType{JobTypeName="校長",SchoolDepartmentId=1},
            //副校長
            new JobType{JobTypeName="副校長",SchoolDepartmentId=2},
            //人事
            new JobType{JobTypeName="人事主任",SchoolDepartmentId=3},
            new JobType{JobTypeName="人事人員",SchoolDepartmentId=3},
            //會計
            new JobType{JobTypeName="會計主任",SchoolDepartmentId=4},
            new JobType{JobTypeName="會計人員",SchoolDepartmentId=4},
            //學務
            new JobType{JobTypeName="學務主任",SchoolDepartmentId=5},
            new JobType{JobTypeName="導師",SchoolDepartmentId=5},
            new JobType{JobTypeName="學務人員",SchoolDepartmentId=5},
            //資訊工程學系
            new JobType{JobTypeName="系主任",SchoolDepartmentId=5,SchoolCollegeId=1},
            new JobType{JobTypeName="導師",SchoolDepartmentId=5,SchoolCollegeId=1},
            new JobType{JobTypeName="學務人員",SchoolDepartmentId=5,SchoolCollegeId=1},
            new JobType{JobTypeName="學生",SchoolCollegeId=1},
            //資管工程學系
            new JobType{JobTypeName="系主任",SchoolDepartmentId=5,SchoolCollegeId=2},
            new JobType{JobTypeName="導師",SchoolDepartmentId=5,SchoolCollegeId=2},
            new JobType{JobTypeName="學務人員",SchoolDepartmentId=5,SchoolCollegeId=2},
            new JobType{JobTypeName="學生",SchoolCollegeId=2},
            //英美語文學系
            new JobType{JobTypeName="系主任",SchoolDepartmentId=5,SchoolCollegeId=3},
            new JobType{JobTypeName="導師",SchoolDepartmentId=5,SchoolCollegeId=3},
            new JobType{JobTypeName="學務人員",SchoolDepartmentId=5,SchoolCollegeId=3},
            new JobType{JobTypeName="學生",SchoolCollegeId=3},
            //教務
            new JobType{JobTypeName="教務主任",SchoolDepartmentId=6},
            new JobType{JobTypeName="教務人員",SchoolDepartmentId=6},
            //資訊
            new JobType{JobTypeName="資訊主任",SchoolDepartmentId=7},
            new JobType{JobTypeName="資訊工程師",SchoolDepartmentId=7},
            };
            jobType.ForEach(s => _context.JobType.Add(s));
            _context.SaveChanges();

            var userState = new List<UserState>
            {
            new UserState{InSchoolState="在職"},
            new UserState{InSchoolState="停職留薪"},
            new UserState{InSchoolState="離職"},
            new UserState{InSchoolState="在校生"},
            new UserState{InSchoolState="休學"},
            new UserState{InSchoolState="離校生"},
            new UserState{InSchoolState="畢業生"},
            new UserState{InSchoolState="延畢生"},
            new UserState{InSchoolState="退休"}
            };
            userState.ForEach(s => _context.UserState.Add(s));
            _context.SaveChanges();

            var applicationUser = new List<ApplicationUser>
            {
            //1位工程師(主任)
            new ApplicationUser{UserName="林o希",Gender=Gender.F,LogonId="EP00000001",PasswordHash=new PasswordHasher().HashPassword("EP00000001"),LockoutEnabled=false,BirthDate=DateTime.Parse("1983-09-01"),IDNo="A123456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=24},
            //1位校長
            new ApplicationUser{UserName="陳o豪",Gender=Gender.M,LogonId="EP00000002",PasswordHash=new PasswordHasher().HashPassword("EP00000002"),LockoutEnabled=false,BirthDate=DateTime.Parse("1973-03-01"),IDNo="A133456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=1},
            //1位副校長
            new ApplicationUser{UserName="林o洪",Gender=Gender.M,LogonId="EP00000003",PasswordHash=new PasswordHasher().HashPassword("EP00000003"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A143456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=2},
            //2位會計師
            new ApplicationUser{UserName="施o文",Gender=Gender.M,LogonId="EP00000004",PasswordHash=new PasswordHasher().HashPassword("EP00000004"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-06-11"),IDNo="A153456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=5},
            new ApplicationUser{UserName="吳o莉",Gender=Gender.M,LogonId="EP00000005",PasswordHash=new PasswordHasher().HashPassword("EP00000005"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A163456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=6},
            //2位人事
            new ApplicationUser{UserName="吳o洪",Gender=Gender.F,LogonId="EP00000006",PasswordHash=new PasswordHasher().HashPassword("EP00000006"),LockoutEnabled=false,BirthDate=DateTime.Parse("1979-06-11"),IDNo="A173456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=3},
            new ApplicationUser{UserName="林o莉",Gender=Gender.M,LogonId="EP00000007",PasswordHash=new PasswordHasher().HashPassword("EP00000007"),LockoutEnabled=false,BirthDate=DateTime.Parse("1979-05-11"),IDNo="A183456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=4},
            //2位學務處
            new ApplicationUser{UserName="潘o真",Gender=Gender.M,LogonId="EP00000008",PasswordHash=new PasswordHasher().HashPassword("EP00000008"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-09-11"),IDNo="A193456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=7},
            new ApplicationUser{UserName="黃o真",Gender=Gender.M,LogonId="EP00000009",PasswordHash=new PasswordHasher().HashPassword("EP00000009"),LockoutEnabled=false,BirthDate=DateTime.Parse("1981-05-11"),IDNo="A203456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=9},
            //2位教務處
            new ApplicationUser{UserName="潘o洪",Gender=Gender.M,LogonId="EP00000010",PasswordHash=new PasswordHasher().HashPassword("EP00000010"),LockoutEnabled=false,BirthDate=DateTime.Parse("1983-10-11"),IDNo="A213456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=22},
            new ApplicationUser{UserName="李o洪",Gender=Gender.M,LogonId="EP00000011",PasswordHash=new PasswordHasher().HashPassword("EP00000011"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A223456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=23},
            //8位老師,1位行政人員(資訊工程學系)
            new ApplicationUser{UserName="林o婷",Gender=Gender.M,LogonId="EP00000012",PasswordHash=new PasswordHasher().HashPassword("EP00000012"),LockoutEnabled=false,BirthDate=DateTime.Parse("1982-03-11"),IDNo="A233456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=12},

            new ApplicationUser{UserName="李o婷",Gender=Gender.F,LogonId="EP00000013",PasswordHash=new PasswordHasher().HashPassword("EP00000013"),LockoutEnabled=false,BirthDate=DateTime.Parse("1979-05-11"),IDNo="A243456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=10},
            new ApplicationUser{UserName="林o紅",Gender=Gender.M,LogonId="EP00000014",PasswordHash=new PasswordHasher().HashPassword("EP00000014"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-23"),IDNo="A253456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=11},
            new ApplicationUser{UserName="黃o婷",Gender=Gender.F,LogonId="EP00000015",PasswordHash=new PasswordHasher().HashPassword("EP00000015"),LockoutEnabled=false,BirthDate=DateTime.Parse("1978-05-17"),IDNo="A263456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=11},
            new ApplicationUser{UserName="曾o龍",Gender=Gender.M,LogonId="EP00000016",PasswordHash=new PasswordHasher().HashPassword("EP00000016"),LockoutEnabled=false,BirthDate=DateTime.Parse("1979-05-16"),IDNo="A273456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=11},
            new ApplicationUser{UserName="李o龍",Gender=Gender.M,LogonId="EP00000017",PasswordHash=new PasswordHasher().HashPassword("EP00000017"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A283456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=11},
            new ApplicationUser{UserName="王o哲",Gender=Gender.M,LogonId="EP00000018",PasswordHash=new PasswordHasher().HashPassword("EP00000018"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A293456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=11},
            new ApplicationUser{UserName="徐o明",Gender=Gender.M,LogonId="EP00000019",PasswordHash=new PasswordHasher().HashPassword("EP00000019"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A303456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=11},
            new ApplicationUser{UserName="黃o菁",Gender=Gender.M,LogonId="EP00000020",PasswordHash=new PasswordHasher().HashPassword("EP00000020"),LockoutEnabled=false,BirthDate=DateTime.Parse("1980-05-08"),IDNo="A313456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=11},
            //4位老師(通識,體育)
            new ApplicationUser{UserName="黃o字",Gender=Gender.M,LogonId="EP00000021",PasswordHash=new PasswordHasher().HashPassword("EP00000021"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A323456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=8},
            new ApplicationUser{UserName="吳o璇",Gender=Gender.M,LogonId="EP00000022",PasswordHash=new PasswordHasher().HashPassword("EP00000022"),LockoutEnabled=false,BirthDate=DateTime.Parse("1980-05-04"),IDNo="A333456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=8},
            new ApplicationUser{UserName="陳o雯",Gender=Gender.M,LogonId="EP00000023",PasswordHash=new PasswordHasher().HashPassword("EP00000023"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A343456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=8},
            new ApplicationUser{UserName="張o卉",Gender=Gender.F,LogonId="EP00000024",PasswordHash=new PasswordHasher().HashPassword("EP00000024"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-02"),IDNo="A353456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=8},
            //8位老師,1位行政人員(資管工程學系)
            new ApplicationUser{UserName="王o則",Gender=Gender.M,LogonId="EP00000025",PasswordHash=new PasswordHasher().HashPassword("EP000000025"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A363456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=16},

            new ApplicationUser{UserName="黃o翠",Gender=Gender.F,LogonId="EP00000026",PasswordHash=new PasswordHasher().HashPassword("EP00000026"),LockoutEnabled=false,BirthDate=DateTime.Parse("1980-05-11"),IDNo="A373456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=14},
            new ApplicationUser{UserName="林o智",Gender=Gender.M,LogonId="EP00000027",PasswordHash=new PasswordHasher().HashPassword("EP00000027"),LockoutEnabled=false,BirthDate=DateTime.Parse("1981-05-11"),IDNo="A383456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=15},
            new ApplicationUser{UserName="徐o系",Gender=Gender.M,LogonId="EP00000028",PasswordHash=new PasswordHasher().HashPassword("EP00000028"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-04-01"),IDNo="A393456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=15},
            new ApplicationUser{UserName="黃o英",Gender=Gender.F,LogonId="EP00000029",PasswordHash=new PasswordHasher().HashPassword("EP00000029"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A403456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=15},
            new ApplicationUser{UserName="黃o霖",Gender=Gender.M,LogonId="EP00000030",PasswordHash=new PasswordHasher().HashPassword("EP00000030"),LockoutEnabled=false,BirthDate=DateTime.Parse("1980-05-21"),IDNo="A413456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=15},
            new ApplicationUser{UserName="黃o惠",Gender=Gender.M,LogonId="EP00000031",PasswordHash=new PasswordHasher().HashPassword("EP00000031"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A423456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=15},
            new ApplicationUser{UserName="陳o衛",Gender=Gender.M,LogonId="EP00000032",PasswordHash=new PasswordHasher().HashPassword("EP00000032"),LockoutEnabled=false,BirthDate=DateTime.Parse("1981-05-22"),IDNo="A433456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=15},
            new ApplicationUser{UserName="余o智",Gender=Gender.M,LogonId="EP00000033",PasswordHash=new PasswordHasher().HashPassword("EP00000033"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A443456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=15},
            //5位老師,1位行政人員(英美語文學系)
            new ApplicationUser{UserName="曾o霖",Gender=Gender.M,LogonId="EP00000034",PasswordHash=new PasswordHasher().HashPassword("EP00000034"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A453456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=20},

            new ApplicationUser{UserName="王o英",Gender=Gender.F,LogonId="EP00000035",PasswordHash=new PasswordHasher().HashPassword("EP00000035"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-01-19"),IDNo="A463456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=18},
            new ApplicationUser{UserName="黃o至",Gender=Gender.M,LogonId="EP00000036",PasswordHash=new PasswordHasher().HashPassword("EP00000036"),LockoutEnabled=false,BirthDate=DateTime.Parse("1979-05-11"),IDNo="A473456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=19},
            new ApplicationUser{UserName="林o泓",Gender=Gender.F,LogonId="EP00000037",PasswordHash=new PasswordHasher().HashPassword("EP00000037"),LockoutEnabled=false,BirthDate=DateTime.Parse("1979-06-13"),IDNo="A483456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=19},
            new ApplicationUser{UserName="張o胃",Gender=Gender.M,LogonId="EP00000038",PasswordHash=new PasswordHasher().HashPassword("EP00000038"),LockoutEnabled=false,BirthDate=DateTime.Parse("1977-05-11"),IDNo="A493456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=19},
            new ApplicationUser{UserName="鄒o繪",Gender=Gender.M,LogonId="EP00000039",PasswordHash=new PasswordHasher().HashPassword("EP00000039"),LockoutEnabled=false,BirthDate=DateTime.Parse("1978-02-15"),IDNo="A503456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=19},
            
            //105
            //資工
            new ApplicationUser{UserName="琳o莉",Gender=Gender.F,LogonId="A115940001",PasswordHash=new PasswordHasher().HashPassword("A115940001"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-08-15"),IDNo="A513456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),Identity=Identity.S,UserStateId=8,JobTypeId=13},

            new ApplicationUser{UserName="陳o菊",Gender=Gender.F,LogonId="A115940002",PasswordHash=new PasswordHasher().HashPassword("A115940002"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-12-24"),IDNo="A523456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            new ApplicationUser{UserName="吳o豪",Gender=Gender.F,LogonId="A115940003",PasswordHash=new PasswordHasher().HashPassword("A115940003"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-07-16"),IDNo="A533456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            new ApplicationUser{UserName="陳o恩",Gender=Gender.F,LogonId="A115940004",PasswordHash=new PasswordHasher().HashPassword("A115940004"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-03-05"),IDNo="A543456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            new ApplicationUser{UserName="陳o憲",Gender=Gender.F,LogonId="A115940005",PasswordHash=new PasswordHasher().HashPassword("A115940005"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-06-09"),IDNo="A553456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},

            new ApplicationUser{UserName="王o平",Gender=Gender.F,LogonId="A115940006",PasswordHash=new PasswordHasher().HashPassword("A115940006"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-07-15"),IDNo="A563456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            new ApplicationUser{UserName="黃o如",Gender=Gender.F,LogonId="A115940007",PasswordHash=new PasswordHasher().HashPassword("A115940007"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-09-13"),IDNo="A573456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            new ApplicationUser{UserName="陳o介",Gender=Gender.F,LogonId="A115940008",PasswordHash=new PasswordHasher().HashPassword("A115940008"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-11-26"),IDNo="A583456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            new ApplicationUser{UserName="陳o事",Gender=Gender.F,LogonId="A115940009",PasswordHash=new PasswordHasher().HashPassword("A115940009"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-02-15"),IDNo="A593456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            new ApplicationUser{UserName="陳o為",Gender=Gender.F,LogonId="A115940010",PasswordHash=new PasswordHasher().HashPassword("A115940010"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-05-15"),IDNo="A603456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=13},
            //資管
            new ApplicationUser{UserName="陳o數",Gender=Gender.F,LogonId="A215940001",PasswordHash=new PasswordHasher().HashPassword("A215940001"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-08-15"),IDNo="A613456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=17},
            new ApplicationUser{UserName="黃o魯",Gender=Gender.F,LogonId="A215940002",PasswordHash=new PasswordHasher().HashPassword("A215940002"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-12-24"),IDNo="A623456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=17},
            new ApplicationUser{UserName="陳o以",Gender=Gender.F,LogonId="A215940003",PasswordHash=new PasswordHasher().HashPassword("A215940003"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-07-16"),IDNo="A633456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=17},
            new ApplicationUser{UserName="陳o演",Gender=Gender.F,LogonId="A215940004",PasswordHash=new PasswordHasher().HashPassword("A215940004"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-03-05"),IDNo="A643456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=17},
            new ApplicationUser{UserName="劉o備",Gender=Gender.F,LogonId="A215940005",PasswordHash=new PasswordHasher().HashPassword("A215940005"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-06-09"),IDNo="A653456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=17},
            //英美
            new ApplicationUser{UserName="王o毫",Gender=Gender.F,LogonId="B115940001",PasswordHash=new PasswordHasher().HashPassword("B115940001"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-08-15"),IDNo="A663456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=21},
            new ApplicationUser{UserName="黃o孺",Gender=Gender.F,LogonId="B115940002",PasswordHash=new PasswordHasher().HashPassword("B115940002"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-12-24"),IDNo="A673456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=21},
            new ApplicationUser{UserName="陳o洪",Gender=Gender.F,LogonId="B115940003",PasswordHash=new PasswordHasher().HashPassword("B115940003"),LockoutEnabled=false,BirthDate=DateTime.Parse("1996-07-16"),IDNo="A683456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=21},
            new ApplicationUser{UserName="陳o安",Gender=Gender.F,LogonId="B115940004",PasswordHash=new PasswordHasher().HashPassword("B115940004"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-03-05"),IDNo="A693456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=21},
            new ApplicationUser{UserName="劉o豪",Gender=Gender.F,LogonId="B115940005",PasswordHash=new PasswordHasher().HashPassword("B115940005"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-06-09"),IDNo="A703456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2016-09-01"),GraduationDate=DateTime.Parse("2020-07-15"),Identity=Identity.S,UserStateId=7,JobTypeId=21},            
            
            
            //106
            //資工
            new ApplicationUser{UserName="陳o口",Gender=Gender.F,LogonId="A115940011",PasswordHash=new PasswordHasher().HashPassword("A115940011"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-08-15"),IDNo="A713456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="林o虹",Gender=Gender.F,LogonId="A115940012",PasswordHash=new PasswordHasher().HashPassword("A115940012"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-12-24"),IDNo="A723456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o位",Gender=Gender.F,LogonId="A115940013",PasswordHash=new PasswordHasher().HashPassword("A115940013"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-07-16"),IDNo="A733456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o署",Gender=Gender.F,LogonId="A115940014",PasswordHash=new PasswordHasher().HashPassword("A115940014"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-03-05"),IDNo="A743456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o婭",Gender=Gender.F,LogonId="A115940015",PasswordHash=new PasswordHasher().HashPassword("A115940015"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-06-09"),IDNo="A753456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},

            new ApplicationUser{UserName="曾o豪",Gender=Gender.F,LogonId="A115940016",PasswordHash=new PasswordHasher().HashPassword("A115940016"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-07-15"),IDNo="A763456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="王o嚎",Gender=Gender.F,LogonId="A115940017",PasswordHash=new PasswordHasher().HashPassword("A115940017"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-09-13"),IDNo="A773456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="炎o如",Gender=Gender.F,LogonId="A115940018",PasswordHash=new PasswordHasher().HashPassword("A115940018"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-11-26"),IDNo="A783456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="王o芽",Gender=Gender.F,LogonId="A115940019",PasswordHash=new PasswordHasher().HashPassword("A115940019"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-02-15"),IDNo="A793456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o雅",Gender=Gender.F,LogonId="A115940020",PasswordHash=new PasswordHasher().HashPassword("A115940020"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-05-15"),IDNo="A803456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            //資管
            new ApplicationUser{UserName="陳o勞",Gender=Gender.F,LogonId="A215940006",PasswordHash=new PasswordHasher().HashPassword("A215940006"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-08-15"),IDNo="A813456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="郭o豪",Gender=Gender.F,LogonId="A215940007",PasswordHash=new PasswordHasher().HashPassword("A215940007"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-12-24"),IDNo="A823456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="陳o爾",Gender=Gender.F,LogonId="A215940008",PasswordHash=new PasswordHasher().HashPassword("A215940008"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-07-16"),IDNo="A833456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="王o嘉",Gender=Gender.F,LogonId="A215940009",PasswordHash=new PasswordHasher().HashPassword("A215940009"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-03-05"),IDNo="A843456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="陳o假",Gender=Gender.F,LogonId="A215940010",PasswordHash=new PasswordHasher().HashPassword("A215940010"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-06-09"),IDNo="A853456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            //英美
            new ApplicationUser{UserName="黃o應",Gender=Gender.F,LogonId="B115940006",PasswordHash=new PasswordHasher().HashPassword("B115940006"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-08-15"),IDNo="A863456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="王o益",Gender=Gender.F,LogonId="B115940007",PasswordHash=new PasswordHasher().HashPassword("B115940007"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-12-24"),IDNo="A873456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o價",Gender=Gender.F,LogonId="B115940008",PasswordHash=new PasswordHasher().HashPassword("B115940008"),LockoutEnabled=false,BirthDate=DateTime.Parse("1997-07-16"),IDNo="A883456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="李o漁",Gender=Gender.F,LogonId="B115940009",PasswordHash=new PasswordHasher().HashPassword("B115940009"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-03-05"),IDNo="A893456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o碘",Gender=Gender.F,LogonId="B115940010",PasswordHash=new PasswordHasher().HashPassword("B115940010"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-06-09"),IDNo="A903456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2017-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},            
            
            
            //107
            //資工
            new ApplicationUser{UserName="林o琳",Gender=Gender.F,LogonId="A115940021",PasswordHash=new PasswordHasher().HashPassword("A115940021"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-08-15"),IDNo="A913456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="李o後",Gender=Gender.F,LogonId="A115940022",PasswordHash=new PasswordHasher().HashPassword("A115940022"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-12-24"),IDNo="A923456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o訝",Gender=Gender.F,LogonId="A115940023",PasswordHash=new PasswordHasher().HashPassword("A115940023"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-07-16"),IDNo="A933456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o汐",Gender=Gender.F,LogonId="A115940024",PasswordHash=new PasswordHasher().HashPassword("A115940024"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-03-05"),IDNo="A943456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o襖",Gender=Gender.F,LogonId="A115940025",PasswordHash=new PasswordHasher().HashPassword("A115940025"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-06-09"),IDNo="A953456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},

            new ApplicationUser{UserName="黃o鹿",Gender=Gender.F,LogonId="A115940026",PasswordHash=new PasswordHasher().HashPassword("A115940026"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-07-15"),IDNo="A963456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o敖",Gender=Gender.F,LogonId="A115940027",PasswordHash=new PasswordHasher().HashPassword("A115940027"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-09-13"),IDNo="A973456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o玉",Gender=Gender.F,LogonId="A115940028",PasswordHash=new PasswordHasher().HashPassword("A115940028"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-11-26"),IDNo="A983456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o足",Gender=Gender.F,LogonId="A115940029",PasswordHash=new PasswordHasher().HashPassword("A115940029"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-02-15"),IDNo="A993456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="沈o毋",Gender=Gender.F,LogonId="A115940030",PasswordHash=new PasswordHasher().HashPassword("A115940030"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-05-15"),IDNo="A100456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            //資管
            new ApplicationUser{UserName="陳o琳",Gender=Gender.F,LogonId="A215940011",PasswordHash=new PasswordHasher().HashPassword("A215940011"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-08-15"),IDNo="A101456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="陳o岸",Gender=Gender.F,LogonId="A215940012",PasswordHash=new PasswordHasher().HashPassword("A215940012"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-12-24"),IDNo="A102456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="王o籃",Gender=Gender.F,LogonId="A215940013",PasswordHash=new PasswordHasher().HashPassword("A215940013"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-07-16"),IDNo="A103456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="林o書",Gender=Gender.F,LogonId="A215940014",PasswordHash=new PasswordHasher().HashPassword("A215940014"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-08-05"),IDNo="A104456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="曾o傲",Gender=Gender.F,LogonId="A215940015",PasswordHash=new PasswordHasher().HashPassword("A215940015"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-06-09"),IDNo="A105456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            //英美
            new ApplicationUser{UserName="陳o薄",Gender=Gender.F,LogonId="B115940011",PasswordHash=new PasswordHasher().HashPassword("B115940011"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-08-15"),IDNo="A106456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o驗",Gender=Gender.F,LogonId="B115940012",PasswordHash=new PasswordHasher().HashPassword("B115940012"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-12-24"),IDNo="A107456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o庭",Gender=Gender.F,LogonId="B115940013",PasswordHash=new PasswordHasher().HashPassword("B115940013"),LockoutEnabled=false,BirthDate=DateTime.Parse("1998-09-16"),IDNo="A108456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="李o樣",Gender=Gender.F,LogonId="B115940014",PasswordHash=new PasswordHasher().HashPassword("B115940014"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-07-05"),IDNo="A109456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="黃o橫",Gender=Gender.F,LogonId="B115940015",PasswordHash=new PasswordHasher().HashPassword("B115940015"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-06-09"),IDNo="A110456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2018-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            
            
            //108
            //資工
            new ApplicationUser{UserName="陳o明",Gender=Gender.F,LogonId="A115940031",PasswordHash=new PasswordHasher().HashPassword("A115940031"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-08-15"),IDNo="A111456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="郭o名",Gender=Gender.F,LogonId="A115940032",PasswordHash=new PasswordHasher().HashPassword("A115940032"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-12-24"),IDNo="A112456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o捷",Gender=Gender.F,LogonId="A115940033",PasswordHash=new PasswordHasher().HashPassword("A115940033"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-07-16"),IDNo="A113456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="郭o立",Gender=Gender.F,LogonId="A115940034",PasswordHash=new PasswordHasher().HashPassword("A115940034"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-03-05"),IDNo="A114456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="黃o露",Gender=Gender.F,LogonId="A115940035",PasswordHash=new PasswordHasher().HashPassword("A115940035"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-06-09"),IDNo="A115456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},

            new ApplicationUser{UserName="林o維",Gender=Gender.F,LogonId="A115940036",PasswordHash=new PasswordHasher().HashPassword("A115940036"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-07-15"),IDNo="A116456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="黃o物",Gender=Gender.F,LogonId="A115940037",PasswordHash=new PasswordHasher().HashPassword("A115940037"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-09-13"),IDNo="A117456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),DropOutDate=DateTime.Parse("2020-05-23"),Identity=Identity.S,UserStateId=5,JobTypeId=13},
            new ApplicationUser{UserName="王o號",Gender=Gender.F,LogonId="A115940038",PasswordHash=new PasswordHasher().HashPassword("A115940038"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-11-26"),IDNo="A118456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o解",Gender=Gender.F,LogonId="A115940039",PasswordHash=new PasswordHasher().HashPassword("A115940039"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-02-15"),IDNo="A119456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o漚",Gender=Gender.F,LogonId="A115940040",PasswordHash=new PasswordHasher().HashPassword("A115940040"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-05-15"),IDNo="A120456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            //資管
            new ApplicationUser{UserName="黃o豪",Gender=Gender.F,LogonId="A215940016",PasswordHash=new PasswordHasher().HashPassword("A215940016"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-08-15"),IDNo="A121456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),LeaveDate=DateTime.Parse("2020-05-23"),Identity=Identity.S,UserStateId=6,JobTypeId=17},
            new ApplicationUser{UserName="陳o杰",Gender=Gender.F,LogonId="A215940017",PasswordHash=new PasswordHasher().HashPassword("A215940017"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-12-24"),IDNo="A122456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="凱o豪",Gender=Gender.F,LogonId="A215940018",PasswordHash=new PasswordHasher().HashPassword("A215940018"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-07-16"),IDNo="A124456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="黃o室",Gender=Gender.F,LogonId="A215940019",PasswordHash=new PasswordHasher().HashPassword("A215940019"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-03-05"),IDNo="A125456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="郭	o嫁",Gender=Gender.F,LogonId="A215940020",PasswordHash=new PasswordHasher().HashPassword("A215940020"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-06-09"),IDNo="A126456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            //英美
            new ApplicationUser{UserName="李o資",Gender=Gender.F,LogonId="B115940016",PasswordHash=new PasswordHasher().HashPassword("B115940016"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-08-15"),IDNo="A127456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o艇",Gender=Gender.F,LogonId="B115940017",PasswordHash=new PasswordHasher().HashPassword("B115940017"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-12-24"),IDNo="A128456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="林o廷",Gender=Gender.F,LogonId="B115940018",PasswordHash=new PasswordHasher().HashPassword("B115940018"),LockoutEnabled=false,BirthDate=DateTime.Parse("1999-07-16"),IDNo="A129456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="黃o盎",Gender=Gender.F,LogonId="B115940019",PasswordHash=new PasswordHasher().HashPassword("B115940019"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-03-05"),IDNo="A130456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="黃o錄",Gender=Gender.F,LogonId="B115940020",PasswordHash=new PasswordHasher().HashPassword("B115940020"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-06-09"),IDNo="A131456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2019-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            
            
            //109
            //資工
            new ApplicationUser{UserName="黃o牙",Gender=Gender.F,LogonId="A115940041",PasswordHash=new PasswordHasher().HashPassword("A115940041"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-08-15"),IDNo="A132456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="李o佳",Gender=Gender.F,LogonId="A115940042",PasswordHash=new PasswordHasher().HashPassword("A115940042"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-12-24"),IDNo="A133456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o家",Gender=Gender.F,LogonId="A115940043",PasswordHash=new PasswordHasher().HashPassword("A115940043"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-07-16"),IDNo="A134456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="鄒o豪",Gender=Gender.F,LogonId="A115940044",PasswordHash=new PasswordHasher().HashPassword("A115940044"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-03-05"),IDNo="A135456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="陳o雨",Gender=Gender.F,LogonId="A115940045",PasswordHash=new PasswordHasher().HashPassword("A115940045"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-06-09"),IDNo="A136456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},

            new ApplicationUser{UserName="陳o蘭",Gender=Gender.F,LogonId="A115940046",PasswordHash=new PasswordHasher().HashPassword("A115940046"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-07-15"),IDNo="A137456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="李o一",Gender=Gender.F,LogonId="A115940047",PasswordHash=new PasswordHasher().HashPassword("A115940047"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-09-13"),IDNo="A138456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="曾o國",Gender=Gender.F,LogonId="A115940048",PasswordHash=new PasswordHasher().HashPassword("A115940048"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-11-26"),IDNo="A139456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="林o系",Gender=Gender.F,LogonId="A115940049",PasswordHash=new PasswordHasher().HashPassword("A115940049"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-02-15"),IDNo="A140456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            new ApplicationUser{UserName="林o吝",Gender=Gender.F,LogonId="A115940050",PasswordHash=new PasswordHasher().HashPassword("A115940050"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-05-15"),IDNo="A141456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=13},
            //資管
            new ApplicationUser{UserName="黃o摁",Gender=Gender.F,LogonId="A215940021",PasswordHash=new PasswordHasher().HashPassword("A215940021"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-08-15"),IDNo="A142456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="陳o晏",Gender=Gender.F,LogonId="A215940022",PasswordHash=new PasswordHasher().HashPassword("A215940022"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-12-24"),IDNo="A143456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="李o魚",Gender=Gender.F,LogonId="A215940023",PasswordHash=new PasswordHasher().HashPassword("A215940023"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-07-16"),IDNo="A144456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="黃o域",Gender=Gender.F,LogonId="A215940024",PasswordHash=new PasswordHasher().HashPassword("A215940024"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-03-05"),IDNo="A145456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            new ApplicationUser{UserName="陳o唱",Gender=Gender.F,LogonId="A215940025",PasswordHash=new PasswordHasher().HashPassword("A215940025"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-06-09"),IDNo="A146456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=17},
            //英美
            new ApplicationUser{UserName="黃o娥",Gender=Gender.F,LogonId="B115940021",PasswordHash=new PasswordHasher().HashPassword("B115940021"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-08-15"),IDNo="A147456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o停",Gender=Gender.F,LogonId="B115940022",PasswordHash=new PasswordHasher().HashPassword("B115940022"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-12-24"),IDNo="A148456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o替",Gender=Gender.F,LogonId="B115940023",PasswordHash=new PasswordHasher().HashPassword("B115940023"),LockoutEnabled=false,BirthDate=DateTime.Parse("2000-07-16"),IDNo="A149456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o自",Gender=Gender.F,LogonId="B115940024",PasswordHash=new PasswordHasher().HashPassword("B115940024"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-03-05"),IDNo="A150456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},
            new ApplicationUser{UserName="陳o昌",Gender=Gender.F,LogonId="B115940025",PasswordHash=new PasswordHasher().HashPassword("B115940025"),LockoutEnabled=false,BirthDate=DateTime.Parse("2001-06-09"),IDNo="A151456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2020-09-01"),Identity=Identity.S,UserStateId=4,JobTypeId=21},

            //1位工程師(一般員工)
            new ApplicationUser{UserName="林o宜",Gender=Gender.M,LogonId="EP00000040",PasswordHash=new PasswordHasher().HashPassword("EP00000040"),LockoutEnabled=false,BirthDate=DateTime.Parse("1983-09-01"),IDNo="A152456789",EmailConfirmed=false,CreatedUserId=1,CreateDate=DateTime.Now,EnrollmentDate=DateTime.Parse("2001-01-01"),Identity=Identity.E,UserStateId=1,JobTypeId=25},

            };

            applicationUser.ForEach(s => _context.ApplicationUser.Add(s));
            _context.SaveChanges();

            var classroom = new List<Classroom>
            {
            //第一教學大樓 20
            new Classroom{SchoolNumber="T10101",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10102",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10103",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10104",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10105",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10106",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10107",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10108",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10109",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10110",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},

            new Classroom{SchoolNumber="T10201",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10202",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10203",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10204",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10205",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10206",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10207",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10208",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10209",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T10210",ClassroomNumber="一般教室",Location="第一教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},

            //第二教學大樓 40
            new Classroom{SchoolNumber="T20101",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20102",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20103",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20104",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20105",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20106",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20107",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20108",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20109",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20110",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},

            new Classroom{SchoolNumber="T20201",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20202",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20203",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20204",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20205",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20206",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20207",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20208",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20209",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="T20210",ClassroomNumber="一般教室",Location="第二教學大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},

            //行政大樓 60
            new Classroom{SchoolNumber="A10101",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10102",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10103",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10104",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10105",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10106",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10107",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10108",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10109",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10110",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="1F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},

            new Classroom{SchoolNumber="A10201",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10202",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10203",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10204",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10205",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10206",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10207",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10208",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10209",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},
            new Classroom{SchoolNumber="A10210",ClassroomNumber="辦公室",Location="第一行政大樓",Floor="2F",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true},

            };
            classroom.ForEach(s => _context.Classroom.Add(s));
            _context.SaveChanges();

            var sectionDepartment = new List<SectionDepartment>
            {
            new SectionDepartment{Section="大學部",Department="資訊工程學系",DepartmentAbbreviation="資工系",CourseSorts=CourseSorts.C},
            new SectionDepartment{Section="大學部",Department="資管工程學系",DepartmentAbbreviation="資管系",CourseSorts=CourseSorts.C},
            new SectionDepartment{Section="大學部",Department="英美語文學系",DepartmentAbbreviation="英語系",CourseSorts=CourseSorts.C},
            new SectionDepartment{Section="大學部",Department="通識中心",DepartmentAbbreviation="通識中心",CourseSorts=CourseSorts.G},
            new SectionDepartment{Section="大學部",Department="共同教育中心",DepartmentAbbreviation="共同中心",CourseSorts=CourseSorts.G},
            new SectionDepartment{Section="碩士班",Department="資訊工程學系",DepartmentAbbreviation="資工系",CourseSorts=CourseSorts.C},
            new SectionDepartment{Section="碩士班",Department="通識教育中心",DepartmentAbbreviation="通識中心",CourseSorts=CourseSorts.G},
            };
            sectionDepartment.ForEach(s => _context.SectionDepartment.Add(s));
            _context.SaveChanges();

            var employee = new List<Employee>
            {
            //1位工程師(主任)
            new Employee{LogonId="EP00000001",Annual=90,Tel="(08)8888888 #0001",JobTitle="工程師",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=41,ApplicationUserId=1},
            //1位校長
            new Employee{LogonId="EP00000002",Annual=90,Tel="(08)8888888 #0002",JobTitle="校長",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=51,ApplicationUserId=2},
            //1位副校長
            new Employee{LogonId="EP00000003",Annual=90,Tel="(08)8888888 #0003",JobTitle="副校長",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=52,ApplicationUserId=3},
            //2位會計師
            new Employee{LogonId="EP00000004",Annual=90,Tel="(08)8888888 #0004",JobTitle="會計師",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=53,ApplicationUserId=4},
            new Employee{LogonId="EP00000005",Annual=90,Tel="(08)8888888 #0005",JobTitle="會計師",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=53,ApplicationUserId=5},
            //2位人事
            new Employee{LogonId="EP00000006",Annual=90,Tel="(08)8888888 #0006",JobTitle="人事",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=54,ApplicationUserId=6},
            new Employee{LogonId="EP00000007",Annual=90,Tel="(08)8888888 #0007",JobTitle="人事",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=54,ApplicationUserId=7},
            //2位學務處
            new Employee{LogonId="EP00000008",Annual=90,Tel="(08)8888888 #0008",JobTitle="行政人員",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=55,ApplicationUserId=8},
            new Employee{LogonId="EP00000009",Annual=90,Tel="(08)8888888 #0009",JobTitle="行政人員",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=55,ApplicationUserId=9},
            //2位教務處
            new Employee{LogonId="EP00000010",Annual=90,Tel="(08)8888888 #0010",JobTitle="行政人員",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=56,ApplicationUserId=10},
            new Employee{LogonId="EP00000011",Annual=90,Tel="(08)8888888 #0011",JobTitle="行政人員",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=56,ApplicationUserId=11},
            //1位行政人員,8位老師
            new Employee{LogonId="EP00000012",Annual=90,Tel="(08)8888888 #0012",JobTitle="行政人員",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=12},

            new Employee{LogonId="EP00000013",Annual=90,Tel="(08)8888888 #0013",ResearchAreas="電子電路設計,數位邏輯電路,",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=13},
            new Employee{LogonId="EP00000014",Annual=90,Tel="(08)8888888 #0014",ResearchAreas="電子電路設計",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=14},
            new Employee{LogonId="EP00000015",Annual=90,Tel="(08)8888888 #0015",ResearchAreas="半導體製程與元件",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=15},
            new Employee{LogonId="EP00000016",Annual=90,Tel="(08)8888888 #0016",ResearchAreas="人工智慧",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=16},
            new Employee{LogonId="EP00000017",Annual=90,Tel="(08)8888888 #0017",ResearchAreas="人工智慧",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=17},
            new Employee{LogonId="EP00000018",Annual=90,Tel="(08)8888888 #0018",ResearchAreas="語言",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=18},
            new Employee{LogonId="EP00000019",Annual=90,Tel="(08)8888888 #0019",ResearchAreas="語言",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=19},
            new Employee{LogonId="EP00000020",Annual=90,Tel="(08)8888888 #0020",ResearchAreas="籃球,羽球",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=42,ApplicationUserId=20},
            //4位老師(通識,體育)
            new Employee{LogonId="EP00000021",Annual=90,Tel="(08)8888888 #0021",ResearchAreas="古典音樂,爵士音樂",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=43,ApplicationUserId=21},
            new Employee{LogonId="EP00000022",Annual=90,Tel="(08)8888888 #0022",ResearchAreas="編織",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=43,ApplicationUserId=22},
            new Employee{LogonId="EP00000023",Annual=90,Tel="(08)8888888 #0023",ResearchAreas="籃球",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=43,ApplicationUserId=23},
            new Employee{LogonId="EP00000024",Annual=90,Tel="(08)8888888 #0024",ResearchAreas="壘球,棒球",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=43,ApplicationUserId=24},
            //1位行政人員,8位老師
            new Employee{LogonId="EP00000025",Annual=90,Tel="(08)8888888 #0025",JobTitle="行政人員",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=25},

            new Employee{LogonId="EP00000026",Annual=90,Tel="(08)8888888 #0026",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=26},
            new Employee{LogonId="EP00000027",Annual=90,Tel="(08)8888888 #0027",ResearchAreas="數位邏輯電路",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=27},
            new Employee{LogonId="EP00000028",Annual=90,Tel="(08)8888888 #0028",ResearchAreas="人工智慧",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=28},
            new Employee{LogonId="EP00000029",Annual=90,Tel="(08)8888888 #0029",ResearchAreas="人工智慧",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=29},
            new Employee{LogonId="EP00000030",Annual=90,Tel="(08)8888888 #0030",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=30},
            new Employee{LogonId="EP00000031",Annual=90,Tel="(08)8888888 #0031",ResearchAreas="籃球,羽球",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=31},
            new Employee{LogonId="EP00000032",Annual=90,Tel="(08)8888888 #0032",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=32},
            new Employee{LogonId="EP00000033",Annual=90,Tel="(08)8888888 #0033",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=44,ApplicationUserId=33},
            //1位行政人員,5位老師
            new Employee{LogonId="EP00000034",Annual=90,Tel="(08)8888888 #0034",JobTitle="行政人員",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=45,ApplicationUserId=34},

            new Employee{LogonId="EP00000035",Annual=90,Tel="(08)8888888 #0035",ResearchAreas="語言",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=45,ApplicationUserId=35},
            new Employee{LogonId="EP00000036",Annual=90,Tel="(08)8888888 #0036",ResearchAreas="語言",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=45,ApplicationUserId=36},
            new Employee{LogonId="EP00000037",Annual=90,Tel="(08)8888888 #0037",ResearchAreas="語言",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=45,ApplicationUserId=37},
            new Employee{LogonId="EP00000038",Annual=90,Tel="(08)8888888 #0038",ResearchAreas="語言",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=45,ApplicationUserId=38},
            new Employee{LogonId="EP00000039",Annual=90,Tel="(08)8888888 #0039",ResearchAreas="語言",JobTitle="教授",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=45,ApplicationUserId=39},
            
            //1位工程師(一般員工)
            new Employee{LogonId="EP00000040",Annual=90,Tel="(08)8888888 #0040",JobTitle="工程師",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ClassroomId=41,ApplicationUserId=140},

            };
            employee.ForEach(s => _context.Employee.Add(s));
            _context.SaveChanges();

            var students = new List<Student>
            {
            //105
            //資工
            new Student{LogonId="A115940001",Annual=105,Grade=5,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=40,SectionDepartmentId=1,UserStateId=8,ClassGuideLogonId="EP00000013"},

            new Student{LogonId="A115940002",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=41,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000013"},
            new Student{LogonId="A115940003",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=42,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000013"},
            new Student{LogonId="A115940004",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=43,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000013"},
            new Student{LogonId="A115940005",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=44,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000013"},

            new Student{LogonId="A115940006",Annual=105,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=45,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940007",Annual=105,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=46,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940008",Annual=105,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=47,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940009",Annual=105,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=48,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940010",Annual=105,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=49,SectionDepartmentId=1,UserStateId=7,ClassGuideLogonId="EP00000014"},
            //資管
            new Student{LogonId="A215940001",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=50,SectionDepartmentId=2,UserStateId=7,ClassGuideLogonId="EP00000026"},
            new Student{LogonId="A215940002",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=51,SectionDepartmentId=2,UserStateId=7,ClassGuideLogonId="EP00000026"},
            new Student{LogonId="A215940003",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=52,SectionDepartmentId=2,UserStateId=7,ClassGuideLogonId="EP00000026"},
            new Student{LogonId="A215940004",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=53,SectionDepartmentId=2,UserStateId=7,ClassGuideLogonId="EP00000026"},
            new Student{LogonId="A215940005",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=54,SectionDepartmentId=2,UserStateId=7,ClassGuideLogonId="EP00000026"},
            //英美
            new Student{LogonId="B115940001",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=55,SectionDepartmentId=3,UserStateId=7,ClassGuideLogonId="EP00000035"},
            new Student{LogonId="B115940002",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=56,SectionDepartmentId=3,UserStateId=7,ClassGuideLogonId="EP00000035"},
            new Student{LogonId="B115940003",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=57,SectionDepartmentId=3,UserStateId=7,ClassGuideLogonId="EP00000035"},
            new Student{LogonId="B115940004",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=58,SectionDepartmentId=3,UserStateId=7,ClassGuideLogonId="EP00000035"},
            new Student{LogonId="B115940005",Annual=105,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=59,SectionDepartmentId=3,UserStateId=7,ClassGuideLogonId="EP00000035"},
            //106
            //資工
            new Student{LogonId="A115940011",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=60,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000015"},
            new Student{LogonId="A115940012",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=61,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000015"},
            new Student{LogonId="A115940013",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=62,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000015"},
            new Student{LogonId="A115940014",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=63,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000015"},
            new Student{LogonId="A115940015",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=64,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000015"},

            new Student{LogonId="A115940016",Annual=106,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=65,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000016"},
            new Student{LogonId="A115940017",Annual=106,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=66,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000016"},
            new Student{LogonId="A115940018",Annual=106,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=67,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000016"},
            new Student{LogonId="A115940019",Annual=106,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=68,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000016"},
            new Student{LogonId="A115940020",Annual=106,Grade=4,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=69,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000016"},
            //資管
            new Student{LogonId="A215940006",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=70,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000027"},
            new Student{LogonId="A215940007",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=71,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000027"},
            new Student{LogonId="A215940008",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=72,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000027"},
            new Student{LogonId="A215940009",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=73,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000027"},
            new Student{LogonId="A215940010",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=74,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000027"},
            //英美
            new Student{LogonId="B115940006",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=75,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000036"},
            new Student{LogonId="B115940007",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=76,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000036"},
            new Student{LogonId="B115940008",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=77,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000036"},
            new Student{LogonId="B115940009",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=78,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000036"},
            new Student{LogonId="B115940010",Annual=106,Grade=4,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=79,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000036"},
            //107
            //資工
            new Student{LogonId="A115940021",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=80,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000017"},
            new Student{LogonId="A115940022",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=81,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000017"},
            new Student{LogonId="A115940023",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=82,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000017"},
            new Student{LogonId="A115940024",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=83,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000017"},
            new Student{LogonId="A115940025",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=84,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000017"},

            new Student{LogonId="A115940026",Annual=107,Grade=3,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=85,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000018"},
            new Student{LogonId="A115940027",Annual=107,Grade=3,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=86,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000018"},
            new Student{LogonId="A115940028",Annual=107,Grade=3,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=87,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000018"},
            new Student{LogonId="A115940029",Annual=107,Grade=3,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=88,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000018"},
            new Student{LogonId="A115940030",Annual=107,Grade=3,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=89,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000018"},
            //資管
            new Student{LogonId="A215940011",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=90,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000028"},
            new Student{LogonId="A215940012",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=91,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000028"},
            new Student{LogonId="A215940013",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=92,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000028"},
            new Student{LogonId="A215940014",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=93,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000028"},
            new Student{LogonId="A215940015",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=94,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000028"},
            //英美
            new Student{LogonId="B115940011",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=95,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000037"},
            new Student{LogonId="B115940012",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=96,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000037"},
            new Student{LogonId="B115940013",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=97,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000037"},
            new Student{LogonId="B115940014",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=98,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000037"},
            new Student{LogonId="B115940015",Annual=107,Grade=3,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=99,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000037"},
            //108
            //資工
            new Student{LogonId="A115940031",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=100,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000019"},
            new Student{LogonId="A115940032",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=101,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000019"},
            new Student{LogonId="A115940033",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=102,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000019"},
            new Student{LogonId="A115940034",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=103,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000019"},
            new Student{LogonId="A115940035",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=104,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000019"},

            new Student{LogonId="A115940036",Annual=108,Grade=2,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=105,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000020"},
            new Student{LogonId="A115940037",Annual=108,Grade=1,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=106,SectionDepartmentId=1,UserStateId=5,ClassGuideLogonId="EP00000020"},
            new Student{LogonId="A115940038",Annual=108,Grade=2,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=107,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000020"},
            new Student{LogonId="A115940039",Annual=108,Grade=2,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=108,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000020"},
            new Student{LogonId="A115940040",Annual=108,Grade=2,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=109,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000020"},
            //資管
            new Student{LogonId="A215940016",Annual=108,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=110,SectionDepartmentId=2,UserStateId=6,ClassGuideLogonId="EP00000029"},
            new Student{LogonId="A215940017",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=111,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000029"},
            new Student{LogonId="A215940018",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=112,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000029"},
            new Student{LogonId="A215940019",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=113,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000029"},
            new Student{LogonId="A215940020",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=114,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000029"},
            //英美
            new Student{LogonId="B115940016",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=115,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000038"},
            new Student{LogonId="B115940017",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=116,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000038"},
            new Student{LogonId="B115940018",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=117,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000038"},
            new Student{LogonId="B115940019",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=118,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000038"},
            new Student{LogonId="B115940020",Annual=108,Grade=2,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=119,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000038"},
            //109
            //資工
            new Student{LogonId="A115940041",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=120,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000013"},
            new Student{LogonId="A115940042",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=121,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000013"},
            new Student{LogonId="A115940043",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=122,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000013"},
            new Student{LogonId="A115940044",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=123,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000013"},
            new Student{LogonId="A115940045",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=124,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000013"},

            new Student{LogonId="A115940046",Annual=109,Grade=1,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=125,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940047",Annual=109,Grade=1,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=126,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940048",Annual=109,Grade=1,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=127,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940049",Annual=109,Grade=1,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=128,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000014"},
            new Student{LogonId="A115940050",Annual=109,Grade=1,Class="B",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=129,SectionDepartmentId=1,UserStateId=4,ClassGuideLogonId="EP00000014"},
            //資管
            new Student{LogonId="A215940021",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=130,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000030"},
            new Student{LogonId="A215940022",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=131,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000030"},
            new Student{LogonId="A215940023",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=132,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000030"},
            new Student{LogonId="A215940024",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=133,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000030"},
            new Student{LogonId="A215940025",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=134,SectionDepartmentId=2,UserStateId=4,ClassGuideLogonId="EP00000030"},
            //英美
            new Student{LogonId="B115940021",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=135,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000039"},
            new Student{LogonId="B115940022",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=136,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000039"},
            new Student{LogonId="B115940023",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=137,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000039"},
            new Student{LogonId="B115940024",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=138,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000039"},
            new Student{LogonId="B115940025",Annual=109,Grade=1,Class="A",CreatedUserId=1,CreateDate=DateTime.Now,IsActive=true,ApplicationUserId=139,SectionDepartmentId=3,UserStateId=4,ClassGuideLogonId="EP00000039"},

            };
            students.ForEach(s => _context.Student.Add(s));
            _context.SaveChanges();

            var pITStatus = new List<PITStatus>
            {
            new PITStatus{StatusCode="Applied",Name="已申請",NextStatusCode="Accepted"},
            new PITStatus{StatusCode="Accepted",Name="已受理",NextStatusCode="Finished"},
            new PITStatus{StatusCode="Canceled",Name="已撤銷"},
            new PITStatus{StatusCode="Finished",Name="已同意"},
            new PITStatus{StatusCode="Rejected",Name="不受理"},
            };
            pITStatus.ForEach(s => _context.PITStatus.Add(s));
            _context.SaveChanges();

            var processNodeTable = new List<ProcessNodeTable>
            {
            //校長
            new ProcessNodeTable{NodeSN="LFS-Pri-001",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=3,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Pri-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Pri-002",NodeName="人事審核",NodeOrder=2,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Pri-003",LastNodeSN="LFS-Pri-001",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Pri-003",NodeName="結案",NodeOrder=3,MinLeaveNum=1,LastNodeSN="LFS-Pri-002",CreateTime=DateTime.Now,CreatedById=1},
            //副校長
            new ProcessNodeTable{NodeSN="LFS-VC-001",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=4,JobTypeName="副校長",JobTypeId=2,NextNodeSN="LFS-VC-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-VC-002",NodeName="校長審核",NodeOrder=2,MinLeaveNum=1,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-VC-003",LastNodeSN="LFS-VC-001",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-VC-003",NodeName="人事審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-VC-004",LastNodeSN="LFS-VC-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-VC-004",NodeName="結案",NodeOrder=4,MinLeaveNum=1,LastNodeSN="LFS-VC-003",CreateTime=DateTime.Now,CreatedById=1},
            //人事主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-001",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-002",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-003",LastNodeSN="LFS-Dir-001",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-003",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-004",LastNodeSN="LFS-Dir-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-004",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-005",LastNodeSN="LFS-Dir-003",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-005",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-004",CreateTime=DateTime.Now,CreatedById=1},

            //人事人員
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-001",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="人事人員",JobTypeId=4,NextNodeSN="LFS-Emp-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-002",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-003",LastNodeSN="LFS-Emp-001",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-003",NodeName="人事主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-004",LastNodeSN="LFS-Emp-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-004",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-005",LastNodeSN="LFS-Emp-003",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-005",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-006",LastNodeSN="LFS-Emp-004",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-006",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-005",CreateTime=DateTime.Now,CreatedById=1},
            
            
            //會計主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-006",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="會計主任",JobTypeId=5,NextNodeSN="LFS-Dir-007",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-007",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-008",LastNodeSN="LFS-Dir-006",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-008",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-009",LastNodeSN="LFS-Dir-007",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-009",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-010",LastNodeSN="LFS-Dir-008",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-010",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-009",CreateTime=DateTime.Now,CreatedById=1},

            //會計人員
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-007",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="會計人員",JobTypeId=6,NextNodeSN="LFS-Emp-008",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-008",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-009",LastNodeSN="LFS-Emp-007",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-009",NodeName="會計主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="會計主任",JobTypeId=5,NextNodeSN="LFS-Emp-010",LastNodeSN="LFS-Emp-008",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-010",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-011",LastNodeSN="LFS-Emp-009",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-011",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-012",LastNodeSN="LFS-Emp-010",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-012",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-011",CreateTime=DateTime.Now,CreatedById=1},


            //學務主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-011",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="學務主任",JobTypeId=7,NextNodeSN="LFS-Dir-012",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-012",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-013",LastNodeSN="LFS-Dir-011",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-013",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-014",LastNodeSN="LFS-Dir-012",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-014",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-015",LastNodeSN="LFS-Dir-013",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-015",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-014",CreateTime=DateTime.Now,CreatedById=1},
            
            //導師
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Tea-001",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="導師",JobTypeId=8,NextNodeSN="LFS-Tea-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-002",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Tea-003",LastNodeSN="LFS-Tea-001",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-003",NodeName="學務主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="學務主任",JobTypeId=7,NextNodeSN="LFS-Tea-004",LastNodeSN="LFS-Tea-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-004",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Tea-005",LastNodeSN="LFS-Tea-003",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-005",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Tea-006",LastNodeSN="LFS-Tea-004",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-006",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Tea-005",CreateTime=DateTime.Now,CreatedById=1},

            //學務人員
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-013",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="學務人員",JobTypeId=9,NextNodeSN="LFS-Emp-014",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-014",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-015",LastNodeSN="LFS-Emp-013",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-015",NodeName="學務主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="學務主任",JobTypeId=7,NextNodeSN="LFS-Emp-016",LastNodeSN="LFS-Emp-014",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-016",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-017",LastNodeSN="LFS-Emp-015",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-017",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-018",LastNodeSN="LFS-Emp-016",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-018",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-017",CreateTime=DateTime.Now,CreatedById=1},
            


            //資訊工程學系
            ////系主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-016",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="系主任",JobTypeId=10,NextNodeSN="LFS-Dir-017",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-017",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-018",LastNodeSN="LFS-Dir-016",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-018",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-019",LastNodeSN="LFS-Dir-017",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-019",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-020",LastNodeSN="LFS-Dir-018",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-020",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-019",CreateTime=DateTime.Now,CreatedById=1},
            ////導師
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Tea-007",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="導師",JobTypeId=11,NextNodeSN="LFS-Tea-008",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-008",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Tea-009",LastNodeSN="LFS-Tea-007",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-009",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="系主任",JobTypeId=10,NextNodeSN="LFS-Tea-010",LastNodeSN="LFS-Tea-008",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-010",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Tea-011",LastNodeSN="LFS-Tea-009",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-011",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Tea-012",LastNodeSN="LFS-Tea-010",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-012",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Tea-011",CreateTime=DateTime.Now,CreatedById=1},
            ////學務人員
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-019",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="學務人員",JobTypeId=12,NextNodeSN="LFS-Emp-020",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-020",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-021",LastNodeSN="LFS-Emp-019",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-021",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="系主任",JobTypeId=10,NextNodeSN="LFS-Emp-022",LastNodeSN="LFS-Emp-020",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-022",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-023",LastNodeSN="LFS-Emp-021",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-023",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-024",LastNodeSN="LFS-Emp-022",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-024",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-023",CreateTime=DateTime.Now,CreatedById=1},
            ////學生
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Stu-001",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="學生",JobTypeId=13,NextNodeSN="LFS-Stu-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-002",NodeName="班導審核",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Stu-003",LastNodeSN="LFS-Stu-001",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-003",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="系主任",JobTypeId=10,NextNodeSN="LFS-Stu-004",LastNodeSN="LFS-Stu-002",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-004",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Stu-005",LastNodeSN="LFS-Stu-003",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-005",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Stu-004",CreateTime=DateTime.Now,CreatedById=1},
            



            //資管工程學系
            ////系主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-021",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="系主任",JobTypeId=14,NextNodeSN="LFS-Dir-022",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-022",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-023",LastNodeSN="LFS-Dir-021",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-023",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-024",LastNodeSN="LFS-Dir-022",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-024",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-025",LastNodeSN="LFS-Dir-023",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-025",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-024",CreateTime=DateTime.Now,CreatedById=1},
            ////導師
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Tea-013",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="導師",JobTypeId=15,NextNodeSN="LFS-Tea-014",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-014",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Tea-015",LastNodeSN="LFS-Tea-013",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-015",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="系主任",JobTypeId=14,NextNodeSN="LFS-Tea-016",LastNodeSN="LFS-Tea-014",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-016",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Tea-017",LastNodeSN="LFS-Tea-015",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-017",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Tea-018",LastNodeSN="LFS-Tea-016",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-018",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Tea-017",CreateTime=DateTime.Now,CreatedById=1},
            ////學務人員
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-025",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="學務人員",JobTypeId=16,NextNodeSN="LFS-Emp-026",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-026",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-027",LastNodeSN="LFS-Emp-025",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-027",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="系主任",JobTypeId=14,NextNodeSN="LFS-Emp-028",LastNodeSN="LFS-Emp-026",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-028",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-029",LastNodeSN="LFS-Emp-027",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-029",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-030",LastNodeSN="LFS-Emp-028",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-030",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-029",CreateTime=DateTime.Now,CreatedById=1},
            ////學生
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Stu-006",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="學生",JobTypeId=17,NextNodeSN="LFS-Stu-007",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-007",NodeName="班導審核",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Stu-008",LastNodeSN="LFS-Stu-006",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-008",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="系主任",JobTypeId=14,NextNodeSN="LFS-Stu-009",LastNodeSN="LFS-Stu-007",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-009",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Stu-010",LastNodeSN="LFS-Stu-008",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-010",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Stu-009",CreateTime=DateTime.Now,CreatedById=1},






            //英美語文學系
            ////系主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-026",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="系主任",JobTypeId=18,NextNodeSN="LFS-Dir-027",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-027",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-028",LastNodeSN="LFS-Dir-026",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-028",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-029",LastNodeSN="LFS-Dir-027",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-029",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-030",LastNodeSN="LFS-Dir-028",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-030",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-029",CreateTime=DateTime.Now,CreatedById=1},
            ////導師
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Tea-019",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="導師",JobTypeId=19,NextNodeSN="LFS-Tea-020",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-020",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Tea-021",LastNodeSN="LFS-Tea-019",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-021",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="系主任",JobTypeId=18,NextNodeSN="LFS-Tea-022",LastNodeSN="LFS-Tea-020",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-022",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Tea-023",LastNodeSN="LFS-Tea-021",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-023",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Tea-024",LastNodeSN="LFS-Tea-022",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Tea-024",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Tea-023",CreateTime=DateTime.Now,CreatedById=1},
            ////學務人員
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-031",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="學務人員",JobTypeId=20,NextNodeSN="LFS-Emp-032",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-032",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-033",LastNodeSN="LFS-Emp-031",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-033",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="系主任",JobTypeId=18,NextNodeSN="LFS-Emp-034",LastNodeSN="LFS-Emp-032",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-034",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-035",LastNodeSN="LFS-Emp-033",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-035",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-036",LastNodeSN="LFS-Emp-034",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-036",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-035",CreateTime=DateTime.Now,CreatedById=1},
            ////學生
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Stu-011",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="學生",JobTypeId=21,NextNodeSN="LFS-Stu-012",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-012",NodeName="班導審核",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Stu-013",LastNodeSN="LFS-Stu-011",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-013",NodeName="系主任審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="系主任",JobTypeId=18,NextNodeSN="LFS-Stu-014",LastNodeSN="LFS-Stu-012",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-014",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Stu-015",LastNodeSN="LFS-Stu-013",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Stu-015",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Stu-014",CreateTime=DateTime.Now,CreatedById=1},





            //教務主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-031",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="教務主任",JobTypeId=22,NextNodeSN="LFS-Dir-032",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-032",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-033",LastNodeSN="LFS-Dir-031",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-033",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-034",LastNodeSN="LFS-Dir-032",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-034",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-035",LastNodeSN="LFS-Dir-033",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-035",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-034",CreateTime=DateTime.Now,CreatedById=1},
            //教務人員
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-037",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="教務人員",JobTypeId=23,NextNodeSN="LFS-Emp-038",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-038",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-039",LastNodeSN="LFS-Emp-037",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-039",NodeName="教務主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="教務主任",JobTypeId=22,NextNodeSN="LFS-Emp-040",LastNodeSN="LFS-Emp-038",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-040",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-041",LastNodeSN="LFS-Emp-039",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-041",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-042",LastNodeSN="LFS-Emp-040",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-042",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-041",CreateTime=DateTime.Now,CreatedById=1},




            //資訊主任
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Dir-036",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=5,JobTypeName="資訊主任",JobTypeId=24,NextNodeSN="LFS-Dir-037",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-037",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Dir-038",LastNodeSN="LFS-Dir-036",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-038",NodeName="校長審核",NodeOrder=3,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Dir-039",LastNodeSN="LFS-Dir-037",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-039",NodeName="人事審核",NodeOrder=4,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Dir-040",LastNodeSN="LFS-Dir-038",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Dir-040",NodeName="結案",NodeOrder=5,MinLeaveNum=1,LastNodeSN="LFS-Dir-039",CreateTime=DateTime.Now,CreatedById=1},

            //資訊工程師
            //請超過3天
            new ProcessNodeTable{NodeSN="LFS-Emp-043",NodeName="假單申請",NodeOrder=1,MinLeaveNum=1,NumberOfTimes=6,JobTypeName="資訊工程師",JobTypeId=25,NextNodeSN="LFS-Emp-044",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-044",NodeName="代理人",NodeOrder=2,MinLeaveNum=1,NextNodeSN="LFS-Emp-045",LastNodeSN="LFS-Emp-043",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-045",NodeName="資訊主任審核",NodeOrder=3,MinLeaveNum=1,JobTypeName="資訊主任",JobTypeId=24,NextNodeSN="LFS-Emp-046",LastNodeSN="LFS-Emp-044",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-046",NodeName="校長審核",NodeOrder=4,MinLeaveNum=4,JobTypeName="校長",JobTypeId=1,NextNodeSN="LFS-Emp-047",LastNodeSN="LFS-Emp-045",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-047",NodeName="人事審核",NodeOrder=5,MinLeaveNum=1,JobTypeName="人事主任",JobTypeId=3,NextNodeSN="LFS-Emp-048",LastNodeSN="LFS-Emp-046",CreateTime=DateTime.Now,CreatedById=1},
            new ProcessNodeTable{NodeSN="LFS-Emp-048",NodeName="結案",NodeOrder=6,MinLeaveNum=1,LastNodeSN="LFS-Emp-047",CreateTime=DateTime.Now,CreatedById=1},



            };
            processNodeTable.ForEach(s => _context.ProcessNodeTable.Add(s));
            _context.SaveChanges();

            var typeOfLeave = new List<TypeOfLeave>
            {
            new TypeOfLeave{TypeOfLeaveName="特休假"},
            new TypeOfLeave{TypeOfLeaveName="公假"},
            new TypeOfLeave{TypeOfLeaveName="事假"},
            new TypeOfLeave{TypeOfLeaveName="病假"},
            new TypeOfLeave{TypeOfLeaveName="公傷病假"},
            new TypeOfLeave{TypeOfLeaveName="喪假"},
            new TypeOfLeave{TypeOfLeaveName="結假"},
            new TypeOfLeave{TypeOfLeaveName="產假"},
            new TypeOfLeave{TypeOfLeaveName="生產前"},
            new TypeOfLeave{TypeOfLeaveName="生產後"},
            new TypeOfLeave{TypeOfLeaveName="流產"},
            new TypeOfLeave{TypeOfLeaveName="生理假"},

            };
            typeOfLeave.ForEach(s => _context.TypeOfLeave.Add(s));
            _context.SaveChanges();

        }

    }
}
