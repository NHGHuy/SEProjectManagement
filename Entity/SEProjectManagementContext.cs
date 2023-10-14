using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity
{
    public partial class SEProjectManagementContext : DbContext
    {
        public SEProjectManagementContext()
        {
        }

        public SEProjectManagementContext(DbContextOptions<SEProjectManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountType> AccountTypes { get; set; } = null!;
        public virtual DbSet<Instructor> Instructors { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectDetail> ProjectDetails { get; set; } = null!;
        public virtual DbSet<ProjectResource> ProjectResources { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<Term> Terms { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<TopicDetail> TopicDetails { get; set; } = null!;
        public virtual DbSet<TopicRegister> TopicRegisters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-QOR9FTDI\\LAB;Uid=sa;Pwd=Jerrynguyen05.14;Database=SEProjectManagement");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.AccountTypeId).HasColumnName("accountTypeID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .HasColumnName("pwd");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK_Account_AccountType");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType");

                entity.Property(e => e.AccountTypeId).HasColumnName("accountTypeID");

                entity.Property(e => e.AccountTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("accountTypeName");

                entity.Property(e => e.Permission)
                    .HasMaxLength(50)
                    .HasColumnName("permission");
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.ToTable("Instructor");

                entity.Property(e => e.InstructorId).HasColumnName("instructorID");

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Birth)
                    .HasColumnType("datetime")
                    .HasColumnName("birth");

                entity.Property(e => e.Degree)
                    .HasMaxLength(50)
                    .HasColumnName("degree");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(4)
                    .HasColumnName("gender");

                entity.Property(e => e.HomeTown)
                    .HasMaxLength(50)
                    .HasColumnName("homeTown");

                entity.Property(e => e.IName)
                    .HasMaxLength(50)
                    .HasColumnName("iName");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Instructor_Account");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.InstructorId).HasColumnName("instructorID");

                entity.Property(e => e.Point)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("point");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(50)
                    .HasColumnName("projectName");

                entity.Property(e => e.Request)
                    .HasMaxLength(50)
                    .HasColumnName("request");

                entity.Property(e => e.Semester).HasColumnName("semester");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Student1Id).HasColumnName("student1ID");

                entity.Property(e => e.Student2Id).HasColumnName("student2ID");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_Project_Instructor");

                entity.HasOne(d => d.Student1)
                    .WithMany(p => p.ProjectStudent1s)
                    .HasForeignKey(d => d.Student1Id)
                    .HasConstraintName("FK_Project_Student1");

                entity.HasOne(d => d.Student2)
                    .WithMany(p => p.ProjectStudent2s)
                    .HasForeignKey(d => d.Student2Id)
                    .HasConstraintName("FK_Project_Student2");
            });

            modelBuilder.Entity<ProjectDetail>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.TagId })
                    .HasName("PK__ProjectD__74FE8D92B539ACF4");

                entity.ToTable("ProjectDetail");

                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.TagId).HasColumnName("tagID");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectDetails)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectDetail_Project");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProjectDetails)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectDetail_Tag");
            });

            modelBuilder.Entity<ProjectResource>(entity =>
            {
                entity.HasKey(e => e.ResourcesId)
                    .HasName("PK__ProjectR__557C33B9E033DD69");

                entity.Property(e => e.ResourcesId).HasColumnName("resourcesID");

                entity.Property(e => e.Link)
                    .HasMaxLength(50)
                    .HasColumnName("link");

                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.ResourcesName)
                    .HasMaxLength(50)
                    .HasColumnName("resourcesName");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectResources)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_ProjectResources_Project");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("studentID");

                entity.Property(e => e.AccountId).HasColumnName("accountID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Birth)
                    .HasColumnType("datetime")
                    .HasColumnName("birth");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Gender)
                    .HasMaxLength(4)
                    .HasColumnName("gender");

                entity.Property(e => e.HomeTown)
                    .HasMaxLength(50)
                    .HasColumnName("homeTown");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.SName)
                    .HasMaxLength(50)
                    .HasColumnName("sName");

                entity.Property(e => e.TermId).HasColumnName("termID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Student_Account");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK_Student_Term");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.TagId).HasColumnName("tagID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.TagName)
                    .HasMaxLength(50)
                    .HasColumnName("tagName");
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.ToTable("Term");

                entity.Property(e => e.TermId).HasColumnName("termID");

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.Term1).HasColumnName("term");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.TopicId).HasColumnName("topicID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.InstructorId).HasColumnName("instructorID");

                entity.Property(e => e.Request)
                    .HasMaxLength(50)
                    .HasColumnName("request");

                entity.Property(e => e.TopicName)
                    .HasMaxLength(50)
                    .HasColumnName("topicName");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_Topic_Instructor");
            });

            modelBuilder.Entity<TopicDetail>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.TopicId })
                    .HasName("PK__TopicDet__57D014C5E23B4F8F");

                entity.ToTable("TopicDetail");

                entity.Property(e => e.TagId).HasColumnName("tagID");

                entity.Property(e => e.TopicId).HasColumnName("topicID");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .HasColumnName("note");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TopicDetails)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicDetail_Tag");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicDetails)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicDetail_Topic");
            });

            modelBuilder.Entity<TopicRegister>(entity =>
            {
                entity.HasKey(e => e.RegisterId)
                    .HasName("PK__TopicReg__0F6736086B465C4C");

                entity.ToTable("TopicRegister");

                entity.Property(e => e.RegisterId).HasColumnName("registerID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Student1Id).HasColumnName("student1ID");

                entity.Property(e => e.Student2Id).HasColumnName("student2ID");

                entity.Property(e => e.TopicId).HasColumnName("topicID");

                entity.HasOne(d => d.Student1)
                    .WithMany(p => p.TopicRegisterStudent1s)
                    .HasForeignKey(d => d.Student1Id)
                    .HasConstraintName("FK_TopicRegister_Student1");

                entity.HasOne(d => d.Student2)
                    .WithMany(p => p.TopicRegisterStudent2s)
                    .HasForeignKey(d => d.Student2Id)
                    .HasConstraintName("FK_TopicRegister_Student2");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicRegisters)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_TopicRegister_Topic");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
