using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using OrganizationUnitsDemo.EntityFramework;

namespace OrganizationUnitsDemo.Migrations.SeedData
{
    public class DefaultLanguagesBuilder
    {
        private readonly OrganizationUnitsDemoDbContext _context;
        public static List<ApplicationLanguage> InitialLanguages { get; private set; }

        static DefaultLanguagesBuilder()
        {
            InitialLanguages = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "famfamfam-flag-gb"),
                new ApplicationLanguage(null, "tr", "Türkçe", "famfamfam-flag-tr"),
                new ApplicationLanguage(null, "zh-CN", "简体中文", "famfamfam-flag-cn")
            };
        }

        public DefaultLanguagesBuilder(OrganizationUnitsDemoDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);

            _context.SaveChanges();
        }
    }
}