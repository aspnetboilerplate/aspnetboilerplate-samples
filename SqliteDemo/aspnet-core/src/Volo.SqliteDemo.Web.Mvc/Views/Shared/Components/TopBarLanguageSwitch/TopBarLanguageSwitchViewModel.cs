﻿using System.Collections.Generic;
using Abp.Localization;

namespace Volo.SqliteDemo.Web.Views.Shared.Components.TopBarLanguageSwitch
{
    public class TopBarLanguageSwitchViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }
    }
}
