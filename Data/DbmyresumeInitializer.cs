using MyResumeOfWPF.PDO;
using System.Diagnostics;

namespace MyresumeWebApplication.Data
{
    public static class DbmyresumeInitializer
    {
        public static void Initialize(MyresumeInfoContext context)
        {
            //检查该数据库存在
            context.Database.EnsureCreated();

            // Look for any basicinfo.
            if (context.BasicinfoRows.Any())
            {
                return;   // DB has been seeded
            }

            var basicinfos = new BasicinfoRow[]
            {
            new BasicinfoRow{NameColumn="Carson",AddressColumn="Alexander",AgeColumn="33",
                EmailColumn="default@email.com",ExperienceColumn="3year",PhonenumberColumn="defaultphone"}         
            };
            foreach (BasicinfoRow b in basicinfos)
            {
                context.BasicinfoRows.Add(b);
            }
            context.SaveChanges();

            var educationRows = new EducationRow[]
            {
            new EducationRow{MajoyColumn="defaultmajoyone",PeriodColumn="defaultyear",
                SchoolnameColumn="defaultschool",StageColumn="defaultsstage",StartColumn="defaultstart"},
            new EducationRow{MajoyColumn="defaultmajoytwo",PeriodColumn="defaultyear",
                SchoolnameColumn="defaultschool",StageColumn="defaultsstage",StartColumn="defaultstart"},
            };
            foreach (EducationRow e in educationRows)
            {
                context.EducationRows.Add(e);
            }
            context.SaveChanges();

            var jobrows = new JobRow[]
            {
            new JobRow{CompanyNameColumn="defaultcompanyOne",DutyColumn="defaultduty",InputColumn="defalutjoin",
                OutputColumn="defaultdepart",TitleColumn="defaulttitleOne"},
            new JobRow{CompanyNameColumn="defaultcompanyTwo",DutyColumn="defaultduty",InputColumn="defalutjoin",
                OutputColumn="defaultdepart",TitleColumn="defaulttitleTwo"},
            };
            foreach (JobRow j in jobrows)
            {
                context.JobRows.Add(j);
            }
            context.SaveChanges();

            var skillrows = new SkillRow[]
            {
            new SkillRow{TopicColumn="defaulttopicOne",ComponentOneColumn="defaultcomponentone",
                ComponentTwoColumn="defalutcomponentwo",ComponentThreeColumn="defaultcomponethree",
                ComponentFourColumn="defaultcomponentfour"},
            new SkillRow{TopicColumn="defaulttopicTwo",ComponentOneColumn="defaultcomponent",
                ComponentTwoColumn="defalutcomponen",ComponentThreeColumn="defaultcomponent",
                ComponentFourColumn="defaultcomponent"},
            };
            foreach (SkillRow s in skillrows)
            {
                context.SkillRows.Add(s);
            }
            context.SaveChanges();
        }
    }
}
