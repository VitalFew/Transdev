using System;
using System.Reflection;

namespace VitalFew.Transdev.Australasia.Data.Api.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}