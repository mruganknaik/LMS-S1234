using Google.Apis.Auth.OAuth2;
using Google.Apis.Classroom.v1;
using Google.Apis.Classroom.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static Google.Apis.Classroom.v1.ClassroomService;

namespace LMS_S1234
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        private static readonly string[] Scopes12 = { Scope.ClassroomRostersReadonly, Scope.ClassroomAnnouncementsReadonly, Scope.ClassroomCoursesReadonly, Scope.ClassroomCourseworkmaterialsReadonly, Scope.ClassroomCourseworkStudents, Scope.ClassroomCourseworkMe, Scope.ClassroomCourseworkMeReadonly, Scope.ClassroomStudentSubmissionsMeReadonly };
        private static readonly string ApplicationName = "Learning Management System";
        string folder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MyGoogleStorage");
        FileStream stream = new FileStream("client_secret_710075663290-9n1h7q4f1nfgstgar43vb71lv5vskg4k.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read);
        UserCredential credential;
        ClassroomService service;
        IList<Course> courses1;
        Course selectedCourse;
        int in1 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Authorization
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            Scopes12,
            "user",
            CancellationToken.None,
            new FileDataStore(folder)).Result;


            // Create Classroom API service.
            service = new ClassroomService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });


            courses1 = populateCourses();

            ListStudentsResponse stud =service.Courses.Students.List(selectedCourse.Id).Execute();
            foreach (Student std in stud.Students)
            {
                ListBox1.Items.Add(std.Profile.Name.FullName);
            }


            ListTeachersResponse techs = service.Courses.Teachers.List(selectedCourse.Id).Execute();
            foreach (Teacher tch in techs.Teachers)
            {
                ListBox2.Items.Add(tch.Profile.Name.FullName);
            }


        }

        public Course getCourse(string name)
        {
            var res = service.Courses.List().Execute();
            foreach (Course cr in res.Courses)
            {
                if (cr.Name == name)
                {
                    return cr;
                }
            }
            return new Course();
        }

        public IList<Course> populateCourses()
        {
            ListCoursesResponse response = service.Courses.List().Execute();

            if (response.Courses != null && response.Courses.Count > 0)
            {

                int i = 0;
                foreach (var course in response.Courses)
                {
                    DropDownList1.Items.Insert(i, course.Name);
                    i++;
                }
                selectedCourse = response.Courses[0];
                return response.Courses;
            }
            else
            {
                selectedCourse = new Course();
                return new List<Course>();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCourse = getCourse(DropDownList1.SelectedValue);

        }
    }
}