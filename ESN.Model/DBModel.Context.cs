﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ESN.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NG5Entities : DbContext
    {
        public NG5Entities()
            : base("name=NG5Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseAssign> CourseAssigns { get; set; }
        public virtual DbSet<CourseContent> CourseContents { get; set; }
        public virtual DbSet<CourseExam> CourseExams { get; set; }
        public virtual DbSet<CourseExamSetting> CourseExamSettings { get; set; }
        public virtual DbSet<CourseList> CourseLists { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<ExamAnswer> ExamAnswers { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<ExaminationDetail> ExaminationDetails { get; set; }
        public virtual DbSet<MediaStorage> MediaStorages { get; set; }
        public virtual DbSet<MSAnswerType> MSAnswerTypes { get; set; }
        public virtual DbSet<MSCategory> MSCategories { get; set; }
        public virtual DbSet<MSContentType> MSContentTypes { get; set; }
        public virtual DbSet<MSCourseLocation> MSCourseLocations { get; set; }
        public virtual DbSet<MSCourseSort> MSCourseSorts { get; set; }
        public virtual DbSet<MSCourseType> MSCourseTypes { get; set; }
        public virtual DbSet<MSDataLanguage> MSDataLanguages { get; set; }
        public virtual DbSet<MSDepartment> MSDepartments { get; set; }
        public virtual DbSet<MSDivision> MSDivisions { get; set; }
        public virtual DbSet<MSExamLevel> MSExamLevels { get; set; }
        public virtual DbSet<MSExamType> MSExamTypes { get; set; }
        public virtual DbSet<MSMediaType> MSMediaTypes { get; set; }
        public virtual DbSet<MSPosition> MSPositions { get; set; }
        public virtual DbSet<MSProgressStatu> MSProgressStatus { get; set; }
        public virtual DbSet<MSWorkExperience> MSWorkExperiences { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TextResource> TextResources { get; set; }
        public virtual DbSet<UserHistorical> UserHistoricals { get; set; }
        public virtual DbSet<UserManagement> UserManagements { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        [DbFunction("NG5Entities", "fnGetMultiLang")]
        public virtual IQueryable<fnGetMultiLang_Result> fnGetMultiLang(string pKey, string pTableName, string pColumnName)
        {
            var pKeyParameter = pKey != null ?
                new ObjectParameter("pKey", pKey) :
                new ObjectParameter("pKey", typeof(string));
    
            var pTableNameParameter = pTableName != null ?
                new ObjectParameter("pTableName", pTableName) :
                new ObjectParameter("pTableName", typeof(string));
    
            var pColumnNameParameter = pColumnName != null ?
                new ObjectParameter("pColumnName", pColumnName) :
                new ObjectParameter("pColumnName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fnGetMultiLang_Result>("[NG5Entities].[fnGetMultiLang](@pKey, @pTableName, @pColumnName)", pKeyParameter, pTableNameParameter, pColumnNameParameter);
        }
    }
}
