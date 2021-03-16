﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Yngdieng.Backend.Db;

namespace Yngdieng.Backend.Migrations
{
    [DbContext(typeof(AdminContext))]
    [Migration("20210316153140_NewSpeakerFields")]
    partial class NewSpeakerFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:Enum:extension_scope", "contrib,dragon_boat")
                .HasAnnotation("Npgsql:Enum:gender", "unspecified,male,female")
                .HasAnnotation("Npgsql:Enum:sandhi_category", "unspecified,sandhi,bengzi")
                .HasAnnotation("Npgsql:Enum:variant", "unspecified,fuzhou_city,lianjiang,cikling")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Yngdieng.Backend.Db.AudioClip", b =>
                {
                    b.Property<int>("AudioClipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("audio_clip_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BlobLocation")
                        .IsRequired()
                        .HasColumnName("blob_location")
                        .HasColumnType("text");

                    b.Property<Instant>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("timestamp");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnName("mime_type")
                        .HasColumnType("text");

                    b.Property<string>("Pronunciation")
                        .IsRequired()
                        .HasColumnName("pronunciation")
                        .HasColumnType("text");

                    b.Property<int?>("SpeakerId")
                        .HasColumnName("speaker_id")
                        .HasColumnType("integer");

                    b.HasKey("AudioClipId")
                        .HasName("pk_audio_clips");

                    b.HasIndex("SpeakerId")
                        .HasName("ix_audio_clips_speaker_id");

                    b.ToTable("audio_clips");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.Extension", b =>
                {
                    b.Property<int>("WordId")
                        .HasColumnName("word_id")
                        .HasColumnType("integer");

                    b.Property<int>("ExtensionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("extension_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string[]>("Contributors")
                        .IsRequired()
                        .HasColumnName("contributors")
                        .HasColumnType("text[]");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnName("explanation")
                        .HasColumnType("text");

                    b.Property<ExtensionScope>("Scope")
                        .HasColumnName("scope")
                        .HasColumnType("extension_scope");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnName("source")
                        .HasColumnType("text");

                    b.HasKey("WordId", "ExtensionId")
                        .HasName("pk_extensions");

                    b.ToTable("extensions");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.Pron", b =>
                {
                    b.Property<int>("WordId")
                        .HasColumnName("word_id")
                        .HasColumnType("integer");

                    b.Property<int>("PronId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pron_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Pronunciation")
                        .IsRequired()
                        .HasColumnName("pronunciation")
                        .HasColumnType("text");

                    b.Property<SandhiCategory?>("SandhiCategory")
                        .HasColumnName("sandhi_category")
                        .HasColumnType("sandhi_category");

                    b.Property<Variant?>("Variant")
                        .HasColumnName("variant")
                        .HasColumnType("variant");

                    b.Property<long?>("Weight")
                        .HasColumnName("weight")
                        .HasColumnType("bigint");

                    b.HasKey("WordId", "PronId")
                        .HasName("pk_prons");

                    b.ToTable("prons");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.PronAudioClip", b =>
                {
                    b.Property<int>("WordId")
                        .HasColumnName("word_id")
                        .HasColumnType("integer");

                    b.Property<int>("PronId")
                        .HasColumnName("pron_id")
                        .HasColumnType("integer");

                    b.Property<int>("AudioClipId")
                        .HasColumnName("audio_clip_id")
                        .HasColumnType("integer");

                    b.HasKey("WordId", "PronId", "AudioClipId")
                        .HasName("pk_pron_audio_clips");

                    b.HasIndex("AudioClipId")
                        .HasName("ix_pron_audio_clips_audio_clip_id");

                    b.ToTable("pron_audio_clips");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("speaker_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Accent")
                        .HasColumnName("accent")
                        .HasColumnType("text");

                    b.Property<string>("AncestralHome")
                        .HasColumnName("ancestral_home")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<string>("DisplayNameSource")
                        .IsRequired()
                        .HasColumnName("display_name_source")
                        .HasColumnType("text");

                    b.Property<Gender>("Gender")
                        .HasColumnName("gender")
                        .HasColumnType("gender");

                    b.Property<string>("Location")
                        .HasColumnName("location")
                        .HasColumnType("text");

                    b.Property<int?>("YearOfBirth")
                        .HasColumnName("year_of_birth")
                        .HasColumnType("integer");

                    b.HasKey("SpeakerId")
                        .HasName("pk_speakers");

                    b.ToTable("speakers");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("word_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Gloss")
                        .HasColumnName("gloss")
                        .HasColumnType("text");

                    b.Property<string>("Hanzi")
                        .IsRequired()
                        .HasColumnName("hanzi")
                        .HasColumnType("text");

                    b.Property<List<string>>("HanziAlternatives")
                        .IsRequired()
                        .HasColumnName("hanzi_alternatives")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("MandarinWords")
                        .IsRequired()
                        .HasColumnName("mandarin_words")
                        .HasColumnType("text[]");

                    b.HasKey("WordId")
                        .HasName("pk_words");

                    b.ToTable("words");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.WordAudioClip", b =>
                {
                    b.Property<int>("WordId")
                        .HasColumnName("word_id")
                        .HasColumnType("integer");

                    b.Property<int>("AudioClipId")
                        .HasColumnName("audio_clip_id")
                        .HasColumnType("integer");

                    b.HasKey("WordId", "AudioClipId")
                        .HasName("pk_word_audio_clips");

                    b.HasIndex("AudioClipId")
                        .HasName("ix_word_audio_clips_audio_clip_id");

                    b.ToTable("word_audio_clips");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.WordList", b =>
                {
                    b.Property<int>("WordListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("word_list_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<Instant>("CreationTime")
                        .HasColumnName("creation_time")
                        .HasColumnType("timestamp");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("text");

                    b.Property<Instant>("UpdateTime")
                        .HasColumnName("update_time")
                        .HasColumnType("timestamp");

                    b.HasKey("WordListId")
                        .HasName("pk_word_lists");

                    b.ToTable("word_lists");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.WordListWord", b =>
                {
                    b.Property<int>("WordListId")
                        .HasColumnName("word_list_id")
                        .HasColumnType("integer");

                    b.Property<int>("WordId")
                        .HasColumnName("word_id")
                        .HasColumnType("integer");

                    b.Property<int>("Ordering")
                        .HasColumnName("ordering")
                        .HasColumnType("integer");

                    b.HasKey("WordListId", "WordId")
                        .HasName("pk_word_list_words");

                    b.HasIndex("WordId")
                        .HasName("ix_word_list_words_word_id");

                    b.ToTable("word_list_words");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.AudioClip", b =>
                {
                    b.HasOne("Yngdieng.Backend.Db.Speaker", null)
                        .WithMany()
                        .HasForeignKey("SpeakerId")
                        .HasConstraintName("fk_audio_clips_speakers_speaker_id");
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.Extension", b =>
                {
                    b.HasOne("Yngdieng.Backend.Db.Word", null)
                        .WithMany()
                        .HasForeignKey("WordId")
                        .HasConstraintName("fk_extensions_words_word_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.Pron", b =>
                {
                    b.HasOne("Yngdieng.Backend.Db.Word", null)
                        .WithMany()
                        .HasForeignKey("WordId")
                        .HasConstraintName("fk_prons_words_word_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.PronAudioClip", b =>
                {
                    b.HasOne("Yngdieng.Backend.Db.AudioClip", null)
                        .WithMany()
                        .HasForeignKey("AudioClipId")
                        .HasConstraintName("fk_pron_audio_clips_audio_clips_audio_clip_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yngdieng.Backend.Db.Pron", null)
                        .WithMany()
                        .HasForeignKey("WordId", "PronId")
                        .HasConstraintName("fk_pron_audio_clips_prons_word_id_pron_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.WordAudioClip", b =>
                {
                    b.HasOne("Yngdieng.Backend.Db.AudioClip", null)
                        .WithMany()
                        .HasForeignKey("AudioClipId")
                        .HasConstraintName("fk_word_audio_clips_audio_clips_audio_clip_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yngdieng.Backend.Db.Word", null)
                        .WithMany()
                        .HasForeignKey("WordId")
                        .HasConstraintName("fk_word_audio_clips_words_word_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Yngdieng.Backend.Db.WordListWord", b =>
                {
                    b.HasOne("Yngdieng.Backend.Db.Word", null)
                        .WithMany()
                        .HasForeignKey("WordId")
                        .HasConstraintName("fk_word_list_words_words_word_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Yngdieng.Backend.Db.WordList", null)
                        .WithMany()
                        .HasForeignKey("WordListId")
                        .HasConstraintName("fk_word_list_words_word_lists_word_list_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
