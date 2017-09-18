using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS4790A2.Models
{
    public class Repository
    {
        /// <summary>
        /// Getls courses from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Course getCourse(int? id)
        {
            Course course = BasicSchool.getCourse(id); 
            return course;
        }
        /// <summary>
        /// Creates courses in the database
        /// </summary>
        /// <param name="course"></param>
        public static void createCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.courses.Add(course);
            db.SaveChanges(); 
        }
        /// <summary>
        /// Deletes courses from the database
        /// </summary>
        /// <param name="course"></param>
        public static void removeCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.courses.Remove(course);
            db.SaveChanges(); 
        }
        /// <summary>
        /// Updates the course information 
        /// </summary>
        /// <param name="course"></param>
        public static void updateCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges(); 
        }
        /// <summary>
        /// Gets a particular section from the database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Section getSection(int? id)
        {
            Section section = BasicSchool.getSection(id);
            return section; 
        }
        /// <summary>
        /// Add a new section
        /// </summary>
        /// <param name="section"></param>
        public static void addSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.sections.Add(section);
            db.SaveChanges(); 
        }
        /// <summary>
        /// Edit an existing section
        /// </summary>
        /// <param name="section"></param>
        public static void updateSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges(); 
        }
        /// <summary>
        /// Remove an existing section
        /// </summary>
        /// <param name="section"></param>
        public static void removeSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.sections.Remove(section);
            db.SaveChanges(); 
        }
        /// <summary>
        /// Get a course and all of the sections available for it 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CourseAndSections getCourseAndSections(int? id)
        {
            CourseAndSections courseAndSection = BasicSchool.getCourseAndSections(id); 
            return courseAndSection; 
        }
    }
    /// <summary>
    /// Not sure what the purpose of this one is yet...
    /// </summary>
    public class CourseAndSections
    {
        public CourseAndSections()
        {

        }

        public Course course { get; set; }
        public List<Section> sections { get; set; }
    }


}