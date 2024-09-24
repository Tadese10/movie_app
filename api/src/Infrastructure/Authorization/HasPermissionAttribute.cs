using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S3993:Custom attributes should be marked with \"System.AttributeUsageAttribute\"", Justification = "<Pending>")]
public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(permission)
    {
    }
}
