namespace ViewsLesson.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SportContext : DbContext
    {
        // Контекст настроен для использования строки подключения "SportContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ViewsLesson.Models.SportContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "SportContext" 
        // в файле конфигурации приложения.
        public SportContext()
            : base("name=SportContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}