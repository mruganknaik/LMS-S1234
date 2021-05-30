﻿using Google.Apis.Auth.OAuth2;
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
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static readonly string[] Scopes12 = { Scope.ClassroomRostersReadonly, Scope.ClassroomAnnouncementsReadonly, Scope.ClassroomCoursesReadonly, Scope.ClassroomCourseworkmaterialsReadonly, Scope.ClassroomCourseworkStudents, Scope.ClassroomCourseworkMe, Scope.ClassroomCourseworkMeReadonly, Scope.ClassroomStudentSubmissionsMeReadonly };
        private static readonly string ApplicationName = "Learning Management System";
        string folder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/MyGoogleStorage");
        FileStream stream = new FileStream("client_secret_710075663290-9n1h7q4f1nfgstgar43vb71lv5vskg4k.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read);
        UserCredential credential;
        ClassroomService service;
        IList<Course> courses1;
        Course selectedCourse;
        int in1=0;
        //FileStream stream = new FileStream("client_secret_748236895797-mg668chs6jjm8fvdll2palcsq4o95tcq.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read);

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
            
            populateAnnouncements(selectedCourse.Id);
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

            if (response.Courses != null && response.Courses.Count > 0 )
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

        public void populateAnnouncements(String id)
        {
          
            ListAnnouncementsResponse response_anc = service.Courses.Announcements.List(id).Execute();
            if (response_anc.Announcements != null && response_anc.Announcements.Count > 0)

            {
                form2maincontainer.Controls.Clear();
                foreach (var anc in response_anc.Announcements)
                {
                    form2maincontainer.Controls.Add(createCard(anc, in1));
                    in1 = in1 + 3;
                }

            }
            else
            {
                Debug.WriteLine("No courses found.");
            }
        }

        public HtmlGenericControl createCard(Announcement anc, int i)
        {

            HtmlGenericControl div1 = new HtmlGenericControl();
            div1.TagName = "div";
            div1.Attributes["class"] = "row";

            HtmlGenericControl div2 = new HtmlGenericControl();
            div2.TagName = "div";
            div2.Attributes["class"] = "col-xs-12 col-sm-12 col-md-12";
            div2.Attributes["style"] = "padding-top: 10px";

            HtmlGenericControl div3 = new HtmlGenericControl();
            div3.TagName = "div";
            div3.Attributes["class"] = "card";

            HtmlGenericControl div4 = new HtmlGenericControl();
            div4.TagName = "div";
            div4.Attributes["class"] = "card-header";
            div4.Attributes["style"] = "background-color: sandybrown";

            HtmlGenericControl h3 = new HtmlGenericControl();
            h3.TagName = "h3";

            Label head = new Label();
            head.ID = "lab" + i;
            i++;
            head.Text = service.UserProfiles.Get(anc.CreatorUserId).Execute().Name.FullName;
 

            HtmlGenericControl div5 = new HtmlGenericControl();
            div5.TagName = "div";
            div5.Attributes["class"] = "card-body";

            HtmlGenericControl p1 = new HtmlGenericControl();
            p1.TagName = "p";
            p1.Attributes["class"] = "card-title";

            Label body1 = new Label();
            body1.ID = "lab" + i;
            i++;
            body1.Text = anc.CreationTime.ToString();

            HtmlGenericControl p2 = new HtmlGenericControl();
            p2.TagName = "p";
            p2.Attributes["class"] = "fs-4 fst-italic card-text";

            Label body2 = new Label();
            body2.ID = "lab" + i;
            i++;
            body2.Text = anc.Text;

            p2.Controls.Add(body2);
            p1.Controls.Add(body1);
            div5.Controls.Add(p2);
            div5.Controls.Add(p1);
            h3.Controls.Add(head);
            div4.Controls.Add(h3);
            div3.Controls.Add(div4);
            div3.Controls.Add(div5);
            div2.Controls.Add(div3);
            div1.Controls.Add(div2);

            return div1;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedCourse = getCourse(DropDownList1.SelectedValue);
            populateAnnouncements(selectedCourse.Id);
        }
    }
}



/* Link link = new Link() { Url = "https://music.youtube.com/watch?v=otD-XbAhMbU&list=RDAMVMotD-XbAhMbU" };
 Attachment at = new Attachment() { Link = link };
 ModifyAttachmentsRequest mar = new ModifyAttachmentsRequest() { AddAttachments = new List<Attachment>() { at } };
 StudentSubmission ss = service.Courses.CourseWork.StudentSubmissions.Get("343229357421", "347786355363", "Cg4I8aWc2YgHEKPFus2PCg").Execute();
 StudentSubmission ss1 = service.Courses.CourseWork.StudentSubmissions.ModifyAttachments(mar, ss.CourseId, ss.CourseWorkId, ss.Id).Execute();*/

//service.Courses.CourseWork.StudentSubmissions.TurnIn(new TurnInStudentSubmissionRequest(), "343229357421", "347786355363", "Cg4I8aWc2YgHEKPFus2PCg").Execute();
//service.Courses.CourseWork.StudentSubmissions.Reclaim(new ReclaimStudentSubmissionRequest(), "343229357421", "347786355363", "Cg4I8aWc2YgHEKPFus2PCg").Execute();

/*ListStudentSubmissionsResponse tec = service.Courses.CourseWork.StudentSubmissions.List("343229357421", "347786355363").Execute();
if (tec.StudentSubmissions != null && tec.StudentSubmissions.Count > 0)
{
    foreach (StudentSubmission al in tec.StudentSubmissions)
    {
        //Student al1 = service.Courses.Students.Get(al.CourseId, al.UserId).Execute();
        Link link = new Link() { Url = "https://music.youtube.com/watch?v=otD-XbAhMbU&list=RDAMVMotD-XbAhMbU" };
        Attachment at = new Attachment() {Link=link };
        ModifyAttachmentsRequest mar = new ModifyAttachmentsRequest() {AddAttachments=new List<Attachment>() { at} };
        StudentSubmission ss = service.Courses.CourseWork.StudentSubmissions.Get(al.CourseId, al.CourseWorkId, al.Id).Execute();
        StudentSubmission ss1 = service.Courses.CourseWork.StudentSubmissions.ModifyAttachments(mar, ss.CourseId, ss.CourseWorkId, ss.Id).Execute();

        //Debug.WriteLine(ss.AssignedGrade);
        Debug.WriteLine(ss1.CourseWorkType);
        Debug.WriteLine(ss1.State);
       // Debug.WriteLine(ss.Late);


    }
}*/


