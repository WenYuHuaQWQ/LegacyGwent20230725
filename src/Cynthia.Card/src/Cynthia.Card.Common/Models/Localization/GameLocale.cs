﻿using System;
using System.Collections.Generic;

namespace Cynthia.Card.Common.Models.Localization
{
    [Serializable]
    public class GameLocale
    {
        public ConfigEntry Info; 
        public IDictionary<string, string> MenuLocales;
        public IDictionary<string, CardLocale> CardLocales;
    }
}
