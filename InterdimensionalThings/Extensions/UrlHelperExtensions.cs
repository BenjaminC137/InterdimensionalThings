using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterdimensionalThings.Controllers;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }

        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }


        public static string ReceiptLink(this IUrlHelper urlHelper, string id, string scheme)
        {
            return urlHelper.Action(
                action: nameof(ReceiptController.Index),
                controller: "Receipt",
                values: new { id },
                protocol: scheme
            );
        }
    }
}
