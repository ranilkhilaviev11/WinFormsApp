using Microsoft.EntityFrameworkCore;
using System.IO;
using WinFormsApp.Model;

namespace WinFormsApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\winformsapp.mdf;Initial Catalog=winformsapp.mdf;Integrated Security=True;Connect Timeout=30;Context Connection=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(t => t.Team)
                .WithMany(a => a.Players)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Player>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);
            modelBuilder.Entity<Team>()
                .Property(t => t.point)
                .HasDefaultValue(0);
            modelBuilder.Entity<Player>().HasKey(p => p.Id);
            modelBuilder.Entity<Player>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().HasData(
                new Team[]
                {
                    new Team {Id =1, name = "Арсенал"},
                    new Team {Id =2, name = "Астон Вилла"},
                    new Team {Id =3, name = "Борнмут"},
                    new Team {Id =4, name = "Брайтон"},
                    new Team {Id =5, name = "Бёрнли"},
                    new Team {Id =6, name = "Вест Хэм"},
                    new Team {Id =7, name = "Вулверхэмптон"},
                    new Team {Id =8, name = "Кристал Пэлас"},
                    new Team {Id =9, name = "Лестер"},
                    new Team {Id =10, name = "Ливерпуль"},
                    new Team {Id =11, name = "Манчестер Сити"},
                    new Team {Id =12, name = "Манчестер Юнайтед"},
                    new Team {Id =13, name = "Норвич"},
                    new Team {Id =14, name = "Ньюкасл"},
                    new Team {Id =15, name = "Саутгемптон"},
                    new Team {Id =16, name = "Тоттенхэм"},
                    new Team {Id =17, name = "Уотфорд"},
                    new Team {Id =18, name = "Челси"},
                    new Team {Id =19, name = "Шеффилд"},
                    new Team {Id =20, name = "Эвертон"}
                }
                );
            modelBuilder.Entity<Player>().HasData(
                new Player[]
                {
                    new Player {Id = 1, Surname = "Джака", Name = "Гранит", TeamId = 1 },
                    new Player {Id = 2, Surname = "Грилиш", Name = "Джек", TeamId = 2 },
                    new Player {Id = 3, Surname = "Френсис", Name = "Саймон", TeamId = 3 },
                    new Player {Id = 4, Surname = "Данк", Name = "Льюис", TeamId = 4 },
                    new Player {Id = 5, Surname = "Ми", Name = "Бен", TeamId = 5 },
                    new Player {Id = 6, Surname = "Нобл", Name = "Марк", TeamId = 6 },
                    new Player {Id = 7, Surname = "Коуди", Name = "Конор", TeamId = 7 },
                    new Player {Id = 8, Surname = "Миливоевич", Name = "Лука", TeamId = 8 },
                    new Player {Id = 9, Surname = "Морган", Name = "Уэс", TeamId = 9 },
                    new Player {Id = 10, Surname = "Хэндерсон", Name = "Джордан", TeamId = 10 },
                    new Player {Id = 11, Surname = "Сильва", Name = "Давид", TeamId = 11 },
                    new Player {Id = 12, Surname = "Янг", Name = "Эшли", TeamId = 12 },
                    new Player {Id = 13, Surname = "Хэнли", Name = "Грант", TeamId = 13 },
                    new Player {Id = 14, Surname = "Ласселлс", Name = "Джамал", TeamId = 14 },
                    new Player {Id = 15, Surname = "Хёйбьерг", Name = "Пьер-Эмиль", TeamId = 15 },
                    new Player {Id = 16, Surname = "Льорис", Name = "Уго", TeamId = 16 },
                    new Player {Id = 17, Surname = "Дини", Name = "Трой", TeamId = 17 },
                    new Player {Id = 18, Surname = "Аспиликуэта", Name = "Сесар", TeamId = 18 },
                    new Player {Id = 19, Surname = "Шарп", Name = "Билли", TeamId = 19 },
                    new Player {Id = 20, Surname = "Коулман", Name = "Шеймус", TeamId = 20 }
                }
                );
        }
    }
}
