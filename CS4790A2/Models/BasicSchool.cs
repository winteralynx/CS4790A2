using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CS4790A2.Models
{

    public class BasicSchool
    {
        //Use for pt II of this assignment 
        public static Course getCourse(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Course course = db.courses.Find(id);
            return course; 
        }

        public static CourseAndSections getCourseAndSections(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            CourseAndSections courseAndSection = new CourseAndSections();
            courseAndSection.course = db.courses.Find(id);
            var sections = db.sections.Where(s => s.courseNumber == courseAndSection.course.courseNumber);
            courseAndSection.sections = sections.ToList();
            return courseAndSection; 
        }

        //Use for pt II of this assignment
        public static List<Course> getAllCourses()
       {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.courses.ToList(); 
        }


        public static Section getSection(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Section section = db.sections.Find(id);
            return section; 
        }   


    }

    [Table("Course")]

    public class Course
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Couse Number")]
        public string courseNumber { get; set; }
        [DisplayName("Course Name")]
        public string courseName { get; set; }
        [Range(0,4)]
        [DisplayName("Credit Hours")]
        public int creditHours { get; set; }
        [DisplayName("Max Enrollment")]
        public int? maxEnrollment { get; set; } //Put a question mark to indicate that the value is Nullable
    }

    [Table("Section")]

    public class Section
    {
        [Key]
        public int Id { get; set; }
        public int sectionID { get; set; }
        public int sectionNumber { get; set; }
        //[DisplayName("Section Number")]
        public string courseNumber { get; set; }
        //[DisplayName("Course Number")]
        public string sectionDays { get; set; }
        //[DisplayName("Section Days")]
        public DateTime sectionTime { get; set; }
    }

    public class BasicSchoolDbContext : DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Section> sections { get; set; }
    }
}