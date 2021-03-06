// <auto-generated />
using System;
using DynamicForms.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DynamicForms.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220617074410_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DynamicForms.Core.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AnswerOptionId")
                        .HasColumnType("int");

                    b.Property<bool?>("OptionSelected")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("SupportProvisionId")
                        .HasColumnType("int");

                    b.Property<int?>("SupportRequestId")
                        .HasColumnType("int");

                    b.Property<string>("TextResponse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnswerOptionId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SupportProvisionId");

                    b.HasIndex("SupportRequestId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.AnswerOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OptionLabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionGroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionGroupId");

                    b.ToTable("AnswerOptions");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.AreaCoverage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CoverageType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AreaCoverages");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("QuestionTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StakeholderType")
                        .HasColumnType("int");

                    b.Property<int>("SupportTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("SupportTypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DisplayType")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportCaseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SupportCaseTypes");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("SupportCategories");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportProvision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupportTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupportTypeId");

                    b.ToTable("SupportProvision");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupportTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupportTypeId");

                    b.ToTable("supportRequests");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AreaCoverageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupportCaseTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaCoverageId");

                    b.HasIndex("SupportCaseTypeId");

                    b.ToTable("SupportTypes");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.Answer", b =>
                {
                    b.HasOne("DynamicForms.Core.Entities.AnswerOption", "AnswerOption")
                        .WithMany()
                        .HasForeignKey("AnswerOptionId");

                    b.HasOne("DynamicForms.Core.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicForms.Core.Entities.SupportProvision", "SupportProvision")
                        .WithMany()
                        .HasForeignKey("SupportProvisionId");

                    b.HasOne("DynamicForms.Core.Entities.SupportRequest", "SupportRequest")
                        .WithMany()
                        .HasForeignKey("SupportRequestId");

                    b.Navigation("AnswerOption");

                    b.Navigation("Question");

                    b.Navigation("SupportProvision");

                    b.Navigation("SupportRequest");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.AnswerOption", b =>
                {
                    b.HasOne("DynamicForms.Core.Entities.Question", "QuestionGroup")
                        .WithMany()
                        .HasForeignKey("QuestionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionGroup");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.Question", b =>
                {
                    b.HasOne("DynamicForms.Core.Entities.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicForms.Core.Entities.SupportType", "SupportType")
                        .WithMany()
                        .HasForeignKey("SupportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuestionType");

                    b.Navigation("SupportType");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportCategory", b =>
                {
                    b.HasOne("DynamicForms.Core.Entities.SupportCategory", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportProvision", b =>
                {
                    b.HasOne("DynamicForms.Core.Entities.SupportType", "SupportType")
                        .WithMany()
                        .HasForeignKey("SupportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SupportType");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportRequest", b =>
                {
                    b.HasOne("DynamicForms.Core.Entities.SupportType", "SupportType")
                        .WithMany()
                        .HasForeignKey("SupportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SupportType");
                });

            modelBuilder.Entity("DynamicForms.Core.Entities.SupportType", b =>
                {
                    b.HasOne("DynamicForms.Core.Entities.AreaCoverage", "AreaCoverage")
                        .WithMany()
                        .HasForeignKey("AreaCoverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DynamicForms.Core.Entities.SupportCaseType", "SupportCaseType")
                        .WithMany()
                        .HasForeignKey("SupportCaseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaCoverage");

                    b.Navigation("SupportCaseType");
                });
#pragma warning restore 612, 618
        }
    }
}
