using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class update_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Email", "FirstName", "GroupId", "LastName", "Phone", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 22, "Fedorov@gmail.com", "Oleg", null, "Fedorov", "+375291111111", 0, null },
                    { 15, 25, "EfremovSergey@mail.ru", "Sergey", null, "Efremov", "+375441232323", 0, null },
                    { 14, 20, "Filimonova@gmail.com", "Alena", null, "Filimonova", "+375441534545", 2, null },
                    { 13, 29, "FistashkaIrina@yandex.by", "Irina", null, "Fistashka", "+375444444444", 0, null },
                    { 11, 22, "MorozNikita@gmail.com", "Nikita", null, "Moroz", "+375440110111", 1, null },
                    { 10, 39, "YakimovMiron@gmail.com", "Miron", null, "Yakimov", "+375441010101", 1, null },
                    { 9, 40, "VaneevaPolina@gmail.com", "Polina", null, "Vaneeva", "+375449999999", 2, null },
                    { 12, 25, "PonimashVitalik@gmail.com", "Vitalik", null, "Ponimash", "+375441212123", 0, null },
                    { 7, 50, "Micinat@gmail.com", "Vladimir", null, "Micinat", "+375447777777", 2, null },
                    { 6, 25, "Sergeenko@yandex.com", "Maxim", null, "Sergeenko", "+375446666666", 2, null },
                    { 5, 25, "Shmigelski@gmail.com", "Arthur", null, "Shmigelski", "+375295555555", 0, null },
                    { 4, 19, "Ivashko@gmail.com", "Sergey", null, "Ivashko", "+375444444444", 0, null },
                    { 3, 17, "Petrov@gmail.com", "Ivan", null, "Petrov", "+375443333333", 1, null },
                    { 2, 26, "Antonov@gmail.com", "Andrey", null, "Antonov", "+375292222222", 2, null },
                    { 8, 46, "Frunze@mail.ru", "Anatoliy", null, "Frunze", "+375448888888", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "Bio", "Email", "FirstName", "LastName", "LinkToProfile", "Phone", "UserId" },
                values: new object[,]
                {
                    { 1, 30, "My name is Vadim Korotkov. I'am full-stack developer. I know all language, frameworks", "Korotkov@mail.ru", "Vadim", "Korotkov", "https://www.linkedin.com/feed/Korotkov", "+375291111111", null },
                    { 2, 32, "My name is Sergey Gromov. I'am a back-end developer on .Net Framework + Java (JS).", "Gromov@yandex.ru", "Sergey", "Gromov", "https://www.linkedin.com/feed/Gromov", "+375292222222", null },
                    { 3, 36, "My name is Andrew Kamilov. I'am front-end developer, know some modern frameworks (Angular, Vue, React)", "Kamilov@yandex.ru", "Andrew", "Kamilov", "https://www.linkedin.com/feed/Kamilov", "+375293333333", null },
                    { 4, 34, "My name is Marina Kuzmina. I am a Design teacher", "Kuzmina@yandex.ru", "Marina", "Kuzmina", "https://www.linkedin.com/feed/Kuzmina", "+375296561723", null },
                    { 5, 27, "My name is Vladimir Vorobei. I am a C# language teacher", "Vorobei@yandex.ru", "Vladimir", "Vorobei", "https://www.linkedin.com/feed/Vorobei", "+375290989093", null }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "ParentId", "Title" },
                values: new object[,]
                {
                    { 2, "	Язык программирования Java находится в числе лидеров во многих рейтингах: TIOBE – на основе подсчёта результатов поисковых запросов, PYPL – по анализу популярности в поисковике Google, IEEE – по комплексу показателей, таких как упоминание в проектах, статьях, вакансиях и других. Такая популярность обусловлена практически безграничными его возможностями и областями применения.\n	Java не зависит от определённой платформы, его называют безопасным, портативным, высокопроизводительным и динамичным языком.", null, "Java" },
                    { 1, "	C# (си шарп) – объектно-ориентированный язык программирования, разработанный компанией Microsoft. Прямой интерес такой крупной корпорации к языку гарантирует, что он продолжит развиваться и находить применение в различных отраслях.\n	C Sharp впитал лучшие качества, а также унаследовал особенности синтаксиса Java и C++. Применяется язык для веб-разработки, создания настольных и мобильных приложений. Если вы записались на курс по C# в Минске для того, чтобы научиться создавать web-проекты, то в дальнейшем вам необходимо освоить инструментарий .NET.", null, ".Net" },
                    { 3, "	UI/UX и web-дизайн ориентирован на создание внешне привлекательных, удобных в использовании и функциональных пользовательских интерфейсов. Чтобы достичь успеха в этой сфере, необходимо обладать художественным вкусом, быть внимательным к деталям, понимать принципы компьютерной графики и визуального дизайна, уметь работать с инструментами (например, Adobe Photoshop, Adobe Illustrator, Sketch, Figma).", null, "Design" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "DurationWeeks", "Level", "Price", "Program", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, ".NET разработчик создаёт приложения, игры на языке программирования C# на платформе .NET, которую поддерживает Microsoft.	Курс поможет с нуля освоить востребованную специальность .NET-разработчика", 8, 0, 1350.0, "1. Вводное. Установка окружения(C#, Visual Studio). Запуск первой программы Console Application.\n2. Типы данных. Переменные. Операторы.\n3. Операторы if/switch.\n4. Циклы.\n5. И многое другое...", "C#", 1 },
                    { 4, "ASP.NET разработчик создаёт приложения и игры на языке программирования C# на платформе .NET, которую поддерживает Microsoft.", 10, 1, 1610.0, "1. Основы MVC: -Паттерн MVC, MVC контроллеры, разработка представлений.\n2. Основы WebApi: -Архитектура REST; -Проектирование RESTful сервисов, Self-Hosted приложения\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики; -DI и паттерн IoC\n4. Работа с данными: -Понятие ORM, Entity Framework; -Основные подходы к проектированию БД: CodeFirst, DatabaseFirst, ModelFirst\n5. И многое другое...", "Промышленная разработка ПО на ASP.NET", 1 },
                    { 7, "Unity - это современный и мощный игровой движок, позволяющий делать игры любого уровня.	Unity-разработчик создаёт игры и приложения почти под все игровые платформы.", 14, 2, 2040.0, "1. Введение в Unity. Hello world с Unity.\n2. Scripts (Cкрипты). Part 1: -Методология; -Игровые объекты и компоненты; -Cлои, ввод данных, теги.\n3. Scripts (Скрипты). Part 2: -Manual: Immediate Mode GUI (IMGUI); -Сопрограммы.\n4. Инструментарий для разработки 2D-игр.\n5. И многое другое...", "Unity", 1 },
                    { 2, "Курс поможет с нуля освоить востребованную специальность Java-разработчика. 	Программа построена таким образом, что вы не просто познакомитесь с основами Java и объектно-ориентированным программированием на нем, 	а научитесь разбираться в типах данных, использовать алгоритмы и коллекции Java. ", 8, 0, 1420.0, "1. Вводное. Установка окружения(Java, Intellij IDEA). Запуск первой программы.\n2. Типы данных. Переменные. Операторы.\n3. Операторы if/switch.\n4. Циклы.\n5. И многое другое...", "Java", 2 },
                    { 5, "Курс подойдет как студентам технических ВУЗов и специалистам, которым интересно освоить новый язык, так и новичкам в программировании. Но для зачисления необходимо будет сдать тесты по логике и английскому языку.", 10, 1, 1650.0, "1. Основы Apache Maven.\n2. Инженерные техники при работе с Apache Maven.\n3. Работа с моделями: -Многослойная архитектура; -Добавление слоя бизнес-логики, паттерн DAO; -Практика.\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL.\n5. И многое другое...", "Промышленная разработка ПО на Java", 2 },
                    { 8, "В одном супер-курсе мы собрали не только все главные технологии с двух сторон (Front-end и Back-end), которые сегодня активно используются в разработке веб-приложений: HTML, CSS, JavaScript, PHP, SQL; но и изучение основ веб-дизайна, общих принципов клиент-серверной архитектуры веб-приложений, ООП, фреймворков ReactJs и Laravel, системы контроля версий Git и сервиса GitHub.", 15, 2, 2570.0, "1. JQuery.\n2. EscmaScript6.\n3. Расширенные возможность JavaScript\n4. Работа с данными: Основные подходы к проектированию БД, Введение в БД и SQL\n5. И многое другое...", "Full-stack developer", 2 },
                    { 3, "Современный дизайн — обширная область, которая тесно соприкасается с ИТ-сферой, а UX/UI-дизайнеры, веб-дизайнеры и дизайнеры интерфейсов — одновременно и художники, и технически подкованные специалисты, востребованные в индустрии.	 Курс поможет с нуля освоить востребованную специальность Design-разработчика", 6, 0, 1250.0, "1. Принципы визуального дизайна.\n2. Особенности UI/UX/web дизайна.\n3. Основы композиции.\n4. Правила работы со шрифтами.\n5. И многое другое...", "Web Design", 3 },
                    { 6, "Этот курс предназначен для тех, кто хочет познакомится поближе с языком JavaScript + языком разметки HTML5 + CCS3.Таким образом, ты станешь Front-end разработчиком с большим уклоном в дизайн.", 8, 1, 1440.0, "1. Знакомство с библиотекой React.\n2. Настройка Git и Webpack.\n3. Глубокое изучение JavaScript.\n4. Твоя первая большая курсовая работа в команде (простой суши-магазин).\n5. И многое другое...", "Веб-разработка на языках HTML, CSS и JavaScript ", 3 },
                    { 9, "Этот курс Angular, React, Vue для тех, кто хочет стать программистом и работать в сфере веб-разработки. 2,5 месяца теории и практического опыта.", 12, 2, 2300.0, "1. Знакомство с библиотекой React\n2.Знакомство с библиотекой Angular\n3. Знакомство с библиотекой Vue\n4. Твоя первая большая курсовая работа в команде (3 проекта на каждом фрэймворке - магазин доставки цветов)\n5. И многое другое...", "Angular, React, Vue", 3 }
                });

            migrationBuilder.InsertData(
                table: "StudentRequests",
                columns: new[] { "Id", "Comments", "CourseId", "Created", "ReadyToStartDate", "Status", "StudentId", "Updated" },
                values: new object[,]
                {
                    { 1, "Хочу учиться на C# (basic) ", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null },
                    { 2, "Хочу учиться на C# (basic)", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2, null },
                    { 7, "Хочу учиться на C# (средний)", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7, null },
                    { 8, "Хочу учиться на С# (средний)", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 8, null },
                    { 3, "Хочу учиться на Java (basic)", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, null },
                    { 4, "Хочу учиться на Java (basic)", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, null },
                    { 9, "Хочу учиться на Java (средний)", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 9, null },
                    { 10, "Хочу учиться на Java (средний)", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 10, null },
                    { 5, "Хочу учиться на Design (basic)", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5, null },
                    { 6, "Хочу учиться на Design (basic)", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 6, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StudentRequests",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
