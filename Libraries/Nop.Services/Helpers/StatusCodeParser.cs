using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Nop.Core.Infrastructure;

namespace Nop.Services.Helpers
{
    public class StatusCodes
    {
        public int value;
        public string name;
    }

    public class StatusCodesHelper
    {
        private static IEnumerable<StatusCodes> _StatusCodesforJDE;

        public StatusCodesHelper(string StatusCodesStringsPath, INopFileProvider fileProvider)
        {
            Initialize(StatusCodesStringsPath, fileProvider);
        }

        private void Initialize(string StatusCodesStringsPath, INopFileProvider fileProvider)
        {
            List<XElement> StatusCode = null;

            using (var sr = new StreamReader(StatusCodesStringsPath))
            {
                StatusCode = XDocument.Load(sr).Root?.Descendants("item")
                    .ToList();
            }

            if (StatusCode != null)
            {
                _StatusCodesforJDE = StatusCode.Select(e => new StatusCodes() { value = Convert.ToInt32(e.Attribute("name")?.Value), name = (e.Attribute("value")?.Value).ToString() });
            }

        }

        public IEnumerable<StatusCodes> statusCodesJDE()
        {
            return _StatusCodesforJDE;
        }

    }
}
