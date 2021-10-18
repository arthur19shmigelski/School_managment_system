using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Core.Models;
using School.Core.Models.Enum;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.EF.Contexts
{
    public static class ModelBuilderExtensions
    {
        public static async Task Initialize(AcademyContext context,
            IServiceProvider serviceProvider,
            UserManager<IdentityUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "admin", "manager", "student" };

            foreach (var roleName in roles)
            {
                roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                }).Wait();
            }

            string email = "admin@email.com";
            string password = "ASDqwe!@3";

            if (userManager.FindByEmailAsync(email).Result == null)
            {
                IdentityUser user = new();
                user.UserName = email;
                user.Email = email;
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "admin").Wait();
                }
            }


            #region Привязка студент - пользователь_системы_student
            var students = context.Students.ToList();

            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    if (userManager.FindByEmailAsync(student.Email).Result == null)
                    {
                        IdentityUser user = new();

                        user.UserName = student.Email;
                        user.Email = student.Email;
                        user.EmailConfirmed = true;

                        string studentPassword = student.Email + "!@3QWe";
                        student.UserId = user.Id;

                        IdentityResult result = userManager.CreateAsync(user, studentPassword).Result;

                        if (result.Succeeded)
                        {
                            userManager.AddToRoleAsync(user, "student").Wait();
                        }
                    }
                }
            }
            #endregion

            #region Привязка учитель - пользователь_системы_manager
            var teachers = context.Teachers.ToList();

            if (teachers.Count > 0)
            {
                foreach (var teacher in teachers)
                {
                    if (userManager.FindByEmailAsync(teacher.Email).Result == null)
                    {
                        IdentityUser user = new();

                        user.UserName = teacher.Email;
                        user.Email = teacher.Email;
                        user.EmailConfirmed = true;

                        string teacherPassword = teacher.Email + "!@3QWe";
                        teacher.UserId = user.Id;

                        IdentityResult result = userManager.CreateAsync(user, teacherPassword).Result;

                        if (result.Succeeded)
                        {
                            userManager.AddToRoleAsync(user, "manager").Wait();
                        }
                    }
                }
            }
            #endregion
        }
        public static void Seed(this ModelBuilder modelBuilder)
        {

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 3 Topics*/
            var topic1 = new Topic()
            {
                Id = 1,
                Title = ".Net",
                Description = "\tC# (си шарп) – объектно-ориентированный язык программирования, разработанный " +
                  "компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он " +
                  "продолжит развиваться и находить применение в различных отраслях." + "\n\t" +
                  "C Sharp впитал лучшие качества, а также унаследовал особенности " +
                  "синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и " +
                  "мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться " +
                  "создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET."

            };
            var topic2 = new Topic()
            {
                Id = 2,
                Title = "Java",
                Description = "\tЯзык программирования Java находится в числе лидеров во многих рейтингах: " +
                "TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google," +
                " IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность" +
                " обусловлена практически безграничными его возможностями и областями применения.\n\tJava не зависит от определённой платформы, " +
                "его называют безопасным, портативным, высокопроизводительным и динамичным языком."
            };
            var topic3 = new Topic()
            {
                Id = 3,
                Title = "Design",
                Description = "\tUI/UX и web-дизайн ориентирован на создание внешне привлекательных, " +
                "удобных в использовании и функциональных пользовательских интерфейсов. Чтобы достичь " +
                "успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, " +
                "понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами " +
                "(например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma)."
            };
            var topic4 = new Topic()
            {
                Id = 4,
                Title = "HR",
                Description = "\tЗачастую можно услышать вопрос, что такое HR-менеджер, как переводится и чем занимается специалист." +
                " Если посмотреть должностную инструкцию, становится понятно, что он разрабатывает систему управления персоналом, расставляет приоритеты, " +
                "развивает сотрудников, прорисовывает цели для них. Помимо этого HR мотивирует, оценивает и ищет нужных специалистов." +
                "\t\n С помощью данного направления вы уверитесь в значимости HR-менеджера в IT-компании и узнаете обо всех тонкостях профессии как в теории," +
                " так и на практике"
            };
            modelBuilder.Entity<Topic>().HasData(topic1, topic2, topic3, topic4);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 9 Courses*/
            var course1 = new Course()
            {
                Id = 1,
                Title = "C#",
                Description = ".NET разработчик создаёт приложения, игры на языке программирования C# на платформе .NET, которую поддерживает Microsoft." +
                "\tКурс поможет с нуля освоить востребованную специальность .NET-разработчика",
                Level = CourseLevel.Beginner,
                Price = 1350,
                DurationWeeks = 8,
                Program = "1. Вводное. Установка окружения(C#, Visual Studio). Запуск первой программы Console Application." +
                "\n2. Типы данных. Переменные. Операторы." +
                "\n3. Операторы if/switch." +
                "\n4. Циклы." +
                "\n5. И многое другое...",
                TopicId = 1
            };

            var course2 = new Course()
            {
                Id = 2,
                Title = "Java",
                Description = "Курс поможет с нуля освоить востребованную специальность Java-разработчика. " +
                "\tПрограмма построена таким образом, что вы не просто познакомитесь с основами Java и объектно-ориентированным программированием на нем," +
                " \tа научитесь разбираться в типах данных, использовать алгоритмы и коллекции Java. ",
                Level = CourseLevel.Beginner,
                Price = 1420,
                DurationWeeks = 8,
                Program = "1. Вводное. Установка окружения(Java, Intellij IDEA). Запуск первой программы." +
                "\n2. Типы данных. Переменные. Операторы." +
                "\n3. Операторы if/switch." +
                "\n4. Циклы." +
                "\n5. И многое другое...",
                TopicId = 2
            };

            var course3 = new Course()
            {
                Id = 3,
                Title = "Web Design",
                Description = "Современный дизайн — обширная область, которая тесно соприкасается с ИТ-сферой, а UX/UI-дизайнеры, " +
                "веб-дизайнеры и дизайнеры интерфейсов — одновременно и художники, и технически подкованные специалисты, востребованные в индустрии." +
                "\t Курс поможет с нуля освоить востребованную специальность Design-разработчика",
                Level = CourseLevel.Beginner,
                Price = 1250,
                DurationWeeks = 6,
                Program = "1. Принципы визуального дизайна." +
                          "\n2. Особенности UI/UX/web дизайна." +
                          "\n3. Основы композиции." +
                          "\n4. Правила работы со шрифтами." +
                          "\n5. И многое другое...",
                TopicId = 3
            };

            var course4 = new Course()
            {
                Id = 4,
                Title = "Промышленная разработка ПО на ASP.NET",
                Level = CourseLevel.Advanced,
                Price = 1610,
                DurationWeeks = 10,
                Description = "ASP.NET разработчик создаёт приложения и игры на языке программирования C# на платформе .NET, которую поддерживает Microsoft.",
                Program = "1. Основы MVC: -Паттерн MVC, MVC контроллеры, разработка представлений." +
                "\n2. Основы WebApi: -Архитектура REST; -Проектирование RESTful сервисов, Self-Hosted приложения" +
                "\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики; -DI и паттерн IoC" +
                "\n4. Работа с данными: -Понятие ORM, Entity Framework; -Основные подходы к проектированию БД: CodeFirst, DatabaseFirst, ModelFirst" +
                "\n5. И многое другое...",
                TopicId = 1
            };

            var course5 = new Course()
            {
                Id = 5,
                Title = "Промышленная разработка ПО на Java",
                Description = "Курс подойдет как студентам технических ВУЗов и специалистам, которым интересно освоить новый язык, " +
                "так и новичкам в программировании. Но для зачисления необходимо будет сдать тесты по логике и английскому языку.",
                Level = CourseLevel.Advanced,
                Price = 1650,
                DurationWeeks = 10,
                Program = "1. Основы Apache Maven." +
                "\n2. Инженерные техники при работе с Apache Maven." +
                "\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики, паттерн DAO; -Практика." +
                "\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL." +
                "\n5. И многое другое...",
                TopicId = 2
            };

            var course6 = new Course()
            {
                Id = 6,
                Title = "Веб-разработка на языках HTML, CSS и JavaScript ",
                Description = "Этот курс предназначен для тех, кто хочет познакомится поближе с языком JavaScript + языком разметки HTML5 + CCS3." +
                "Таким образом, ты станешь Front-end разработчиком с большим уклоном в дизайн.",
                Level = CourseLevel.Advanced,
                Price = 1440,
                DurationWeeks = 8,
                Program = "1. Знакомство с библиотекой React." +
                          "\n2. Настройка Git и Webpack." +
                          "\n3. Глубокое изучение JavaScript." +
                          "\n4. Твоя первая большая курсовая работа в команде (простой суши-магазин)." +
                          "\n5. И многое другое...",
                TopicId = 3
            };

            var course7 = new Course()
            {
                Id = 7,
                Title = "Unity",
                Description = "Unity - это современный и мощный игровой движок, позволяющий делать игры любого уровня." +
                "\tUnity-разработчик создаёт игры и приложения почти под все игровые платформы.",
                Level = CourseLevel.Expert,
                Price = 2040,
                DurationWeeks = 14,
                Program = "1. Введение в Unity. Hello world с Unity." +
                "\n2. Scripts (Cкрипты). Part 1: -Методология; -Игровые объекты и компоненты; -Cлои, ввод данных, теги." +
                "\n3. Scripts (Скрипты). Part 2: -Manual: Immediate Mode GUI (IMGUI); -Сопрограммы." +
                "\n4. Инструментарий для разработки 2D-игр." +
                "\n5. И многое другое...",
                TopicId = 1
            };

            var course8 = new Course()
            {
                Id = 8,
                Title = "Full-stack developer",
                Description = "В одном супер-курсе мы собрали не только все главные технологии с двух сторон (Front-end и Back-end)," +
                " которые сегодня активно используются в разработке веб-приложений: HTML, CSS, JavaScript, PHP, SQL; но и изучение " +
                "основ веб-дизайна, общих принципов клиент-серверной архитектуры веб-приложений, ООП, фреймворков ReactJs и Laravel, " +
                "системы контроля версий Git и сервиса GitHub.",
                Level = CourseLevel.Expert,
                Price = 2570,
                DurationWeeks = 15,
                Program = "1. JQuery." +
                "\n2. EscmaScript6." +
                "\n3. Расширенные возможность JavaScript" +
                "\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL" +
                "\n5. И многое другое...",
                TopicId = 2
            };

            var course9 = new Course()
            {
                Id = 9,
                Title = "Angular, React, Vue",
                Description = "Этот курс Angular, React, Vue для тех, кто хочет стать программистом и работать в сфере веб-разработки. 2,5 месяца теории и практического опыта.",
                Level = CourseLevel.Expert,
                Price = 2300,
                DurationWeeks = 12,
                Program = "1. Знакомство с библиотекой React" +
                          "\n2.Знакомство с библиотекой Angular" +
                          "\n3. Знакомство с библиотекой Vue" +
                          "\n4. Твоя первая большая курсовая работа в команде (3 проекта на каждом фрэймворке - магазин доставки цветов)" +
                          "\n5. И многое другое...",
                TopicId = 3
            };

            var course10 = new Course()
            {
                Id = 10,
                Title = "IT-HR интенсив - для маленьких компаний",
                Description = "Курс рассчитан на подготовку рекрутеров, работающих в отраслях IT, IOT, R&D и высокотехнологичного производства." +
                "Курс рассчитан на подготовку рекрутеров, работающих в отраслях IT, IOT, R&D и высокотехнологичного производства." +
                "За годы существования программа постоянно совершенствовалась. Сейчас в ней выдержан баланс теории и практики, остались только темы и занятия, " +
                "непосредственно связанные с работой ИТ-рекрутера." +
                "Благодаря практическим заданиям, моделирующим работу ИТ-рекрутера, за 4 недели ученики успевают " +
                "полностью овладеть профессиональными инструментами рекрутера и могут приступать к работе уже во время обучения.",
                Level = CourseLevel.Beginner,
                Price = 1240,
                DurationWeeks = 4,
                Program = "1. Разобраться с основными понятиями и терминами IT-рекрутинга" +
                          "\n2. Освоить технологии и методы подбора персонала" +
                          "\n3. Изучить алгоритмы адаптации новых сотрудников" +
                          "\n4. Узнать, как управлять эффективностью персонала" +
                          "\n5. Ознакомиться с понятиями «HR-бренд компании» и «HR-бренд рекрутера»...",
                TopicId = 4
            };
            var course11 = new Course()
            {
                Id = 11,
                Title = "IT-HR Middle - для средних и крупных компаний",
                Description = "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент." +
               "IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам." +
               "Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.",
                Level = CourseLevel.Advanced,
                Price = 1570,
                DurationWeeks = 5,
                Program = "1. Инструменты анализа" +
                         "\n2. Освоить технологии и методы  двухфакторной теории мотивации Герцберга" +
                         "\n3. Изучить алгоритмы адаптации новых сотрудников" +
                         "\n4. Узнать, как управлять эффективностью персонала" +
                         "\n5. Создание корпоративной культуры и идентификация компании на рынке...",
                TopicId = 4
            };
            var course12 = new Course()
            {
                Id = 12,
                Title = "IT-HR интенсив - для крупных организаций, производств...",
                Description = "Поиск сотрудников на открытые вакансии, помощь в адаптации новым коллегам, работа с коллективом, развитие корпоративной культуры..." +
                " Задач в сфере HR сегодня много. Как во всем разобраться и понять специфику работы в IT? Решить эти вопросы поможет данный курс." +
                "После обучения вы будете понимать, подходит ли вам работа HR в IT, а также то, в какой компании хотите работать и чем можете быть ей полезны. " +
                "Выпускники смогут претендовать на позицию associate/junior HR. Средняя зарплата у опытных специалистов в этой сфере – свыше 1300 долларов.",
                Level = CourseLevel.Expert,
                Price = 2040,
                DurationWeeks = 8,
                Program = "1. Разобраться с основными понятиями и терминами IT-рекрутинга;" +
                         "\n2. Совершенствование корпоративной культуры, условий труда;" +
                         "\n3. УАттестация и оценка сотрудников (в том числе – «материальная», то есть определение премиальной части ЗП, оплаты на основе KPI);" +
                         "\n4. частие в оперативном управлении и решение текущих вопросов;" +
                         "\n5. Ознакомиться с понятиями «HR-бренд компании» и «HR-бренд рекрутера»...",
                TopicId = 4
            };
            modelBuilder.Entity<Course>().HasData(course1, course2, course3,
                course4, course5, course6,
                course7, course8, course9, 
                course10, course11, course12);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 5 Teachers*/
            var teacher1 = new Teacher()
            {
                Id = 1,
                FirstName = "Вадим",
                LastName = "Коротков",
                LinkToProfile = "https://www.linkedin.com/feed/Korotkov",
                Bio = "Меня зовут Вадим Коротков. Я full-stack developer. Я знаю много языков программирования и frameworks",
                Age = 30,
                Email = "Korotkov@mail.ru",
                Phone = "+375291656733",
            };
            var teacher2 = new Teacher()
            {
                Id = 2,
                FirstName = "Сергей",
                LastName = "Громов",
                LinkToProfile = "https://www.linkedin.com/feed/Gromov",
                Bio = "Меня зовут Сергей Громов. Я back-end developer на .Net Framework + Java (JS).",
                Age = 32,
                Email = "Gromov@yandex.ru",
                Phone = "+375292593534"
            };
            var teacher3 = new Teacher()
            {
                Id = 3,
                FirstName = "Андрей",
                LastName = "Камилов",
                LinkToProfile = "https://www.linkedin.com/feed/Kamilov",
                Bio = "Меня зовут Андрей Камилов. Я front-end developer, знаю некоторые современные frameworks (Angular, Vue, React)",
                Age = 36,
                Email = "Kamilov@mail.ru",
                Phone = "+375293334567"
            };

            var teacher4 = new Teacher()
            {
                Id = 4,
                FirstName = "Марина",
                LastName = "Кузьмина",
                LinkToProfile = "https://www.linkedin.com/feed/Kuzmina",
                Bio = "Меня зовут Marina Kuzmina. Я учитель по направлению",
                Age = 34,
                Email = "Kuzmina@yandex.ru",
                Phone = "+375296561723"
            };
            var teacher5 = new Teacher()
            {
                Id = 5,
                FirstName = "Владимир",
                LastName = "Воробей",
                LinkToProfile = "https://www.linkedin.com/feed/Vorobei",
                Bio = "Меня зовут Владимир Воробей. Я .Net developer со стажем 3",
                Age = 31,
                Email = "Vorobei@gmail.com",
                Phone = "+375290989093"
            };

            /*------------------------------------------------------------------------------------------------------------------------*/


            var teacher6 = new Teacher()
            {
                Id = 6,
                FirstName = "Аристарх",
                LastName = "Кузнецов",
                LinkToProfile = "https://www.linkedin.com/feed/Kuznecov",
                Bio = "Меня зовут Аристарх. Попытаюсь объяснить тебе о .Net",
                Age = 32,
                Email = "KuzNica@gmail.com",
                Phone = "+375290984628",
            };
            var teacher7 = new Teacher()
            {
                Id = 7,
                FirstName = "Анисий",
                LastName = "Виноградов",
                LinkToProfile = "https://www.linkedin.com/feed/Vinogradov",
                Bio = "Я Анисий Виноградов. Есть практический опыт на Java, JS, примерно 8 лет.",
                Age = 45,
                Email = "AnisVinograd@yandex.ru",
                Phone = "+375298762334"
            };
            var teacher8 = new Teacher()
            {
                Id = 8,
                FirstName = "Аннатолий",
                LastName = "Голубев",
                LinkToProfile = "https://www.linkedin.com/feed/Golubev",
                Bio = "Меня зовут Аннатолий. Я front-end developer, знаю некоторые современные frameworks (Angular, Vue, React)",
                Age = 43,
                Email = "Kamilov@yandex.ru",
                Phone = "+375291324354"
            };

            var teacher9 = new Teacher()
            {
                Id = 9,
                FirstName = "Аркадий",
                LastName = "Гусев",
                LinkToProfile = "https://www.linkedin.com/feed/Gusev",
                Bio = "My name is Arkadiy Gusev. I am a Design teacher",
                Age = 22,
                Email = "ArkadiyGusev@yandex.ru",
                Phone = "+375294567890"
            };
            var teacher10 = new Teacher()
            {
                Id = 10,
                FirstName = "Хасбик",
                LastName = "Лазарев",
                LinkToProfile = "https://www.linkedin.com/feed/Lazarev",
                Bio = "My name is Lazarev Hasbik. I am a C# language teacher",
                Age = 49,
                Email = "LazarKiller@yandex.ru",
                Phone = "+375296263434"
            };
            modelBuilder.Entity<Teacher>().HasData(teacher1, teacher2, teacher3, teacher4, teacher5,
                teacher6, teacher7, teacher8, teacher9,teacher10);

            /*------------------------------------------------------------------------------------------------------------------------*/
            /*Seed for 15 students*/



            var student1 = new Student()
            {
                Id = 1,
                FirstName = "Олег",
                LastName = "Федоров",
                Email = "Fedorov@gmail.com",
                Age = 22,
                Phone = "+375296711906",
                Type = StudentType.Online,
            };
            var student2 = new Student()
            {
                Id = 2,
                FirstName = "Адрей",
                LastName = "Антонов",
                Email = "Antonov@gmail.com",
                Age = 26,
                Phone = "+375293452992",
                Type = StudentType.Mix,
            };
            var student3 = new Student()
            {
                Id = 3,
                FirstName = "Иван",
                LastName = "Петров",
                Email = "Petrov@gmail.com",
                Age = 17,
                Phone = "+375443567033",
                Type = StudentType.InClass,
            };
            var student4 = new Student()
            {
                Id = 4,
                FirstName = "Сергей",
                LastName = "Ивашко",
                Email = "Ivashko@gmail.com",
                Age = 19,
                Phone = "+375444236424",
                Type = StudentType.Online,
            };
            var student5 = new Student()
            {
                Id = 5,
                FirstName = "Артур",
                LastName = "Шмигельский",
                Email = "Shmigelski@gmail.com",
                Age = 25,
                Phone = "+375295900865",
                Type = StudentType.Online,
            };
            var student6 = new Student()
            {
                Id = 6,
                FirstName = "Виктор",
                LastName = "Сергеенко",
                Email = "Sergeenko@yandex.com",
                Age = 25,
                Phone = "+375446668906",
                Type = StudentType.Mix,
            };
            var student7 = new Student()
            {
                Id = 7,
                FirstName = "Владимир",
                LastName = "Мицинат",
                Email = "Micinat@gmail.com",
                Age = 50,
                Phone = "+375443525757",
                Type = StudentType.Mix,
            };
            var student8 = new Student()
            {
                Id = 8,
                FirstName = "Анатолий",
                LastName = "Фрунзе",
                Email = "Frunze@mail.ru",
                Age = 46,
                Phone = "+375448839528",
                Type = StudentType.InClass,
            };
            var student9 = new Student()
            {
                Id = 9,
                FirstName = "Апполинария",
                LastName = "Ванеева",
                Email = "VaneevaPolina@gmail.com",
                Age = 40,
                Phone = "+375449992359",
                Type = StudentType.Mix,
            };
            var student10 = new Student()
            {
                Id = 10,
                FirstName = "Мирон",
                LastName = "Якимов",
                Email = "YakimovMiron@gmail.com",
                Age = 39,
                Phone = "+375441010744",
                Type = StudentType.InClass,
            };
            var student11 = new Student()
            {
                Id = 11,
                FirstName = "Никита",
                LastName = "Мороз",
                Email = "MorozNikita@gmail.com",
                Age = 22,
                Phone = "+375440169910",
                Type = StudentType.InClass,
            };
            var student12 = new Student()
            {
                Id = 12,
                FirstName = "Виталик",
                LastName = "Понимаш",
                Email = "PonimashVitalik@gmail.com",
                Age = 25,
                Phone = "+375441364123",
                Type = StudentType.Online,
            };
            var student13 = new Student()
            {
                Id = 13,
                FirstName = "Ирэн",
                LastName = "Фисташка",
                Email = "FistashkaIrina@yandex.by",
                Age = 29,
                Phone = "+375444444966",
                Type = StudentType.Online,
            };
            var student14 = new Student()
            {
                Id = 14,
                FirstName = "Алёна",
                LastName = "Филимонова",
                Email = "Filimonova@gmail.com",
                Age = 20,
                Phone = "+375441534784",
                Type = StudentType.Mix,
            };
            var student15 = new Student()
            {
                Id = 15,
                FirstName = "Сергей",
                LastName = "Ефремов",
                Email = "EfremovSergey@mail.ru",
                Age = 25,
                Phone = "+375441234543",
                Type = StudentType.Online,
            };
            /*------------------------------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------------------------------*/
            var student16 = new Student()
            {
                Id = 16,
                FirstName = "Владимир",
                LastName = "Соловьёв",
                Email = "Russia@gmail.com",
                Age = 22,
                Phone = "+375291111111",
                Type = StudentType.Online,
            };
            var student17 = new Student()
            {
                Id = 17,
                FirstName = "Микита",
                LastName = "Беляев",
                Email = "IamMikita@gmail.com",
                Age = 26,
                Phone = "+375292222345",
                Type = StudentType.Mix,
            };
            var student18 = new Student()
            {
                Id = 18,
                FirstName = "Игорь",
                LastName = "Орлов",
                Email = "OrlovIgor1998@gmail.com",
                Age = 17,
                Phone = "+375443332435",
                Type = StudentType.InClass,
            };
            var student19 = new Student()
            {
                Id = 19,
                FirstName = "Алексей",
                LastName = "Баранов",
                Email = "BaranovAlex@gmail.com",
                Age = 19,
                Phone = "+375444443445",
                Type = StudentType.Online,
            };
            var student20 = new Student()
            {
                Id = 20,
                FirstName = "Кулич",
                LastName = "Куликов",
                Email = "Kulikov@gmail.com",
                Age = 25,
                Phone = "+375295340090",
                Type = StudentType.Online,
            };
            var student21 = new Student()
            {
                Id = 21,
                FirstName = "Макс",
                LastName = "Алексеев",
                Email = "AlexMax375@yandex.com",
                Age = 25,
                Phone = "+375446634312",
                Type = StudentType.Mix,
            };
            var student22 = new Student()
            {
                Id = 22,
                FirstName = "Ян",
                LastName = "Яковлев",
                Email = "YakovlevYanik@gmail.com",
                Age = 50,
                Phone = "+375447734545",
                Type = StudentType.Mix,
            };
            var student23 = new Student()
            {
                Id = 23,
                FirstName = "Митя",
                LastName = "Сорокин",
                Email = "Sorokin998@mail.ru",
                Age = 46,
                Phone = "+375448991010",
                Type = StudentType.InClass,
            };
            var student24 = new Student()
            {
                Id = 24,
                FirstName = "Сергей",
                LastName = "Сергеев",
                Email = "SergeevSerg@gmail.com",
                Age = 40,
                Phone = "+375449345432",
                Type = StudentType.Mix,
            };
            var student25 = new Student()
            {
                Id = 25,
                FirstName = "Роман",
                LastName = "Романов",
                Email = "RomanovRoman@gmail.com",
                Age = 39,
                Phone = "+375441010134",
                Type = StudentType.InClass,
            };
            var student26 = new Student()
            {
                Id = 26,
                FirstName = "Евдаким",
                LastName = "Захаров",
                Email = "ZaharovEvdakim@gmail.com",
                Age = 22,
                Phone = "+375440134445",
                Type = StudentType.InClass,
            };
            var student27 = new Student()
            {
                Id = 27,
                FirstName = "Антон",
                LastName = "Борисов",
                Email = "Borisov@gmail.com",
                Age = 25,
                Phone = "+375442929293",
                Type = StudentType.Online,
            };
            var student28 = new Student()
            {
                Id = 28,
                FirstName = "Аристарх",
                LastName = "Королёв",
                Email = "KingSize@yandex.by",
                Age = 29,
                Phone = "+375444423342",
                Type = StudentType.Online,
            };
            var student29 = new Student()
            {
                Id = 29,
                FirstName = "Арсений",
                LastName = "Пономарёв",
                Email = "Ponomar@gmail.com",
                Age = 33,
                Phone = "+375441230909",
                Type = StudentType.Mix,
            };
            var student30 = new Student()
            {
                Id = 30,
                FirstName = "Артём",
                LastName = "Григорьев",
                Email = "GriwaArtem@mail.ru",
                Age = 20,
                Phone = "+375449998877",
                Type = StudentType.Online,
            };
            modelBuilder.Entity<Student>().HasData(
               student1, student2, student3,
               student4, student5, student6,
               student7, student8, student9,
               student10, student11, student12,
               student13, student14, student15,
               student16, student17, student18,
               student19, student20, student21,
               student22, student23, student24,
               student25, student26, student27,
               student28, student29, student30);

            modelBuilder.Entity<StudentRequest>().HasData(
                new StudentRequest
                {
                    Id = 1,
                    CourseId = course1.Id,
                    ReadyToStartDate = new DateTime(2021, 8, 20),
                    StudentId = student1.Id,
                    Comments = "Хочу учиться на C# (basic) ",
                    Status = RequestStatus.Open
                },
                new StudentRequest
                {
                    Id = 2,
                    CourseId = course1.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 11),
                    StudentId = student2.Id,
                    Comments = "Хочу учиться на C# (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 3,
                    CourseId = course2.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 15),
                    StudentId = student3.Id,
                    Comments = "Хочу учиться на Java (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 4,
                    CourseId = course2.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 11),
                    StudentId = student4.Id,
                    Comments = "Хочу учиться на Java (basic)",
                    Status = RequestStatus.Open
                },
                new StudentRequest
                {
                    Id = 5,
                    CourseId = course3.Id,
                    ReadyToStartDate = new DateTime(2021, 9, 5),
                    StudentId = student5.Id,
                    Comments = "Хочу учиться на Design (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 6,
                    CourseId = course3.Id,
                    ReadyToStartDate = new DateTime(2021, 8, 15),
                    StudentId = student6.Id,
                    Comments = "Хочу учиться на Design (basic)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 7,
                    CourseId = course4.Id,
                    ReadyToStartDate = new DateTime(2021, 9, 2),
                    StudentId = student7.Id,
                    Comments = "Хочу учиться на C# (средний)",
                    Status = RequestStatus.Open
                },
                new StudentRequest
                {
                    Id = 8,
                    CourseId = course4.Id,
                    ReadyToStartDate = new DateTime(2021, 8, 22),
                    StudentId = student8.Id,
                    Comments = "Хочу учиться на С# (средний)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 9,
                    CourseId = course5.Id,
                    ReadyToStartDate = new DateTime(2021, 9, 3),
                    StudentId = student9.Id,
                    Comments = "Хочу учиться на Java (средний)",
                    Status = RequestStatus.Open
                }, new StudentRequest
                {
                    Id = 10,
                    CourseId = course5.Id,
                    ReadyToStartDate = new DateTime(2021, 7, 11),
                    StudentId = student10.Id,
                    Comments = "Хочу учиться на Java (средний)",
                    Status = RequestStatus.Open
                }
            );
        }
    }
}