using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class update_seed_data_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Олег", "Федоров", "+375296711906" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Адрей", "Антонов", "+375293452992" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Иван", "Петров", "+375443567033" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Сергей", "Ивашко", "+375444236424" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Артур", "Шмигельский", "+375295900865" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Виктор", "Сергеенко", "+375446668906" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Владимир", "Мицинат", "+375443525757" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Анатолий", "Фрунзе", "+375448839528" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Апполинария", "Ванеева", "+375449992359" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Мирон", "Якимов", "+375441010744" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Никита", "Мороз", "+375440169910" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Виталик", "Понимаш", "+375441364123" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Ирэн", "Фисташка", "+375444444966" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Алёна", "Филимонова", "+375441534784" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Сергей", "Ефремов", "+375441234543" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "ParentId", "Title" },
                values: new object[] { 4, "	Зачастую можно услышать вопрос, что такое HR-менеджер, как переводится и чем занимается специалист. Если посмотреть должностную инструкцию, становится понятно, что он разрабатывает систему управления персоналом, расставляет приоритеты, развивает сотрудников, прорисовывает цели для них. Помимо этого HR мотивирует, оценивает и ищет нужных специалистов.	\n С помощью данного направления вы уверитесь в значимости HR-менеджера в IT-компании и узнаете обо всех тонкостях профессии как в теории, так и на практике", null, "HR" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "DurationWeeks", "Level", "Price", "Program", "Title", "TopicId" },
                values: new object[] { 10, "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент.IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам.Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.", 4, 0, 1240.0, "1. Разобраться с основными понятиями и терминами IT-рекрутинга\n2. Освоить технологии и методы подбора персонала\n3. Изучить алгоритмы адаптации новых сотрудников\n4. Узнать, как управлять эффективностью персонала\n5. Ознакомиться с понятиями «HR-бренд компании» и «HR-бренд рекрутера»...", "IT-HR интенсив - для маленьких компаний", 4 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "DurationWeeks", "Level", "Price", "Program", "Title", "TopicId" },
                values: new object[] { 11, "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент.IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам.Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.", 5, 1, 1570.0, "1. Инструменты анализа\n2. Освоить технологии и методы  двухфакторной теории мотивации Герцберга\n3. Изучить алгоритмы адаптации новых сотрудников\n4. Узнать, как управлять эффективностью персонала\n5. Создание корпоративной культуры и идентификация компании на рынке...", "IT-HR Middle - для средних и крупных компаний", 4 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "DurationWeeks", "Level", "Price", "Program", "Title", "TopicId" },
                values: new object[] { 12, "IT-HR — это специалист, деятельность которого объединяет IT-рекрутинг и HR-менеджмент.IT-HR работает с коллективом компании, развивает корпоративную культуру, помогает адаптироваться новым коллегам.Основная задача HR-менеджера — сопровождение сотрудника на протяжении всего времени его работы в компании.", 8, 2, 2040.0, "1. Разобраться с основными понятиями и терминами IT-рекрутинга;\n2. Совершенствование корпоративной культуры, условий труда;\n3. УАттестация и оценка сотрудников (в том числе – «материальная», то есть определение премиальной части ЗП, оплаты на основе KPI);\n4. частие в оперативном управлении и решение текущих вопросов;\n5. Ознакомиться с понятиями «HR-бренд компании» и «HR-бренд рекрутера»...", "IT-HR интенсив - для крупных организаций, производств...", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Oleg", "Fedorov", "+375291111906" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Andrey", "Antonov", "+375293452222" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Ivan", "Petrov", "+375443357033" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Sergey", "Ivashko", "+375444446424" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Arthur", "Shmigelski", "+375295900555" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Maxim", "Sergeenko", "+375446668676" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Vladimir", "Micinat", "+375443577757" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Anatoliy", "Frunze", "+375448888428" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Polina", "Vaneeva", "+375449999559" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Miron", "Yakimov", "+375441010144" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Nikita", "Moroz", "+375440110110" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Vitalik", "Ponimash", "+375441212123" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Irina", "Fistashka", "+375444444425" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Alena", "Filimonova", "+375441534545" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "FirstName", "LastName", "Phone" },
                values: new object[] { "Sergey", "Efremov", "+375441232323" });
        }
    }
}
