using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class update_seed_data_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "+375291111906");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Phone",
                value: "+375293452222");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Phone",
                value: "+375443357033");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "Phone",
                value: "+375444446424");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "Phone",
                value: "+375295900555");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "Phone",
                value: "+375446668676");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "Phone",
                value: "+375443577757");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                column: "Phone",
                value: "+375448888428");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                column: "Phone",
                value: "+375449999559");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                column: "Phone",
                value: "+375441010144");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                column: "Phone",
                value: "+375440110110");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                column: "Phone",
                value: "+375444444425");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Email", "FirstName", "GroupId", "LastName", "Phone", "Type", "UserId" },
                values: new object[,]
                {
                    { 30, 20, "GriwaArtem@mail.ru", "Артём", null, "Григорьев", "+375449998877", 0, null },
                    { 16, 22, "Russia@gmail.com", "Владимир", null, "Соловьёв", "+375291111111", 0, null },
                    { 28, 29, "KingSize@yandex.by", "Аристарх", null, "Королёв", "+375444423342", 0, null },
                    { 17, 26, "IamMikita@gmail.com", "Микита", null, "Беляев", "+375292222345", 2, null },
                    { 18, 17, "OrlovIgor1998@gmail.com", "Игорь", null, "Орлов", "+375443332435", 1, null },
                    { 19, 19, "BaranovAlex@gmail.com", "Алексей", null, "Баранов", "+375444443445", 0, null },
                    { 20, 25, "Kulikov@gmail.com", "Кулич", null, "Куликов", "+375295340090", 0, null },
                    { 21, 25, "AlexMax375@yandex.com", "Макс", null, "Алексеев", "+375446634312", 2, null },
                    { 22, 50, "YakovlevYanik@gmail.com", "Ян", null, "Яковлев", "+375447734545", 2, null },
                    { 29, 33, "Ponomar@gmail.com", "Арсений", null, "Пономарёв", "+375441230909", 2, null },
                    { 23, 46, "Sorokin998@mail.ru", "Митя", null, "Сорокин", "+375448991010", 1, null },
                    { 25, 39, "RomanovRoman@gmail.com", "Роман", null, "Романов", "+375441010134", 1, null },
                    { 26, 22, "ZaharovEvdakim@gmail.com", "Евдаким", null, "Захаров", "+375440134445", 1, null },
                    { 27, 25, "Borisov@gmail.com", "Антон", null, "Борисов", "+375442929293", 0, null },
                    { 24, 40, "SergeevSerg@gmail.com", "Сергей", null, "Сергеев", "+375449345432", 2, null }
                });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "FirstName", "LastName", "Phone" },
                values: new object[] { "Меня зовут Вадим Коротков. Я full-stack developer. Я знаю много языков программирования и frameworks", "Вадим", "Коротков", "+375291656733" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "FirstName", "LastName", "Phone" },
                values: new object[] { "Меня зовут Сергей Громов. Я back-end developer на .Net Framework + Java (JS).", "Сергей", "Громов", "+375292593534" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bio", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { "Меня зовут Андрей Камилов. Я front-end developer, знаю некоторые современные frameworks (Angular, Vue, React)", "Kamilov@mail.ru", "Андрей", "Камилов", "+375293334567" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Bio", "FirstName", "LastName" },
                values: new object[] { "Меня зовут Marina Kuzmina. Я учитель по направлению", "Марина", "Кузьмина" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Age", "Bio", "Email", "FirstName", "LastName" },
                values: new object[] { 31, "Меня зовут Владимир Воробей. Я .Net developer со стажем 3", "Vorobei@gmail.com", "Владимир", "Воробей" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "Bio", "Email", "FirstName", "LastName", "LinkToProfile", "Phone", "UserId" },
                values: new object[,]
                {
                    { 8, 43, "Меня зовут Аннатолий. Я front-end developer, знаю некоторые современные frameworks (Angular, Vue, React)", "Kamilov@yandex.ru", "Аннатолий", "Голубев", "https://www.linkedin.com/feed/Golubev", "+375291324354", null },
                    { 7, 45, "Я Анисий Виноградов. Есть практический опыт на Java, JS, примерно 8 лет.", "AnisVinograd@yandex.ru", "Анисий", "Виноградов", "https://www.linkedin.com/feed/Vinogradov", "+375298762334", null },
                    { 6, 32, "Меня зовут Аристарх. Попытаюсь объяснить тебе о .Net", "KuzNica@gmail.com", "Аристарх", "Кузнецов", "https://www.linkedin.com/feed/Kuznecov", "+375290984628", null },
                    { 10, 49, "My name is Lazarev Hasbik. I am a C# language teacher", "LazarKiller@yandex.ru", "Хасбик", "Лазарев", "https://www.linkedin.com/feed/Lazarev", "+375296263434", null },
                    { 9, 22, "My name is Arkadiy Gusev. I am a Design teacher", "ArkadiyGusev@yandex.ru", "Аркадий", "Гусев", "https://www.linkedin.com/feed/Gusev", "+375294567890", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Phone",
                value: "+375291111111");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Phone",
                value: "+375292222222");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Phone",
                value: "+375443333333");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "Phone",
                value: "+375444444444");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "Phone",
                value: "+375295555555");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "Phone",
                value: "+375446666666");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "Phone",
                value: "+375447777777");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                column: "Phone",
                value: "+375448888888");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                column: "Phone",
                value: "+375449999999");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                column: "Phone",
                value: "+375441010101");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                column: "Phone",
                value: "+375440110111");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                column: "Phone",
                value: "+375444444444");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "FirstName", "LastName", "Phone" },
                values: new object[] { "My name is Vadim Korotkov. I'am full-stack developer. I know all language, frameworks", "Vadim", "Korotkov", "+375291111111" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bio", "FirstName", "LastName", "Phone" },
                values: new object[] { "My name is Sergey Gromov. I'am a back-end developer on .Net Framework + Java (JS).", "Sergey", "Gromov", "+375292222222" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Bio", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { "My name is Andrew Kamilov. I'am front-end developer, know some modern frameworks (Angular, Vue, React)", "Kamilov@yandex.ru", "Andrew", "Kamilov", "+375293333333" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Bio", "FirstName", "LastName" },
                values: new object[] { "My name is Marina Kuzmina. I am a Design teacher", "Marina", "Kuzmina" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Age", "Bio", "Email", "FirstName", "LastName" },
                values: new object[] { 27, "My name is Vladimir Vorobei. I am a C# language teacher", "Vorobei@yandex.ru", "Vladimir", "Vorobei" });
        }
    }
}
