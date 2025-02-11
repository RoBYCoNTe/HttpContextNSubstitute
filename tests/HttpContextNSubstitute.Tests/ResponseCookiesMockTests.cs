﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace HttpContextNSubstitute.Tests
{
    public class ResponseCookiesMockTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ResponseCookiesMock_WhenRun_AssertTrue(UnitTest<ResponseCookiesMock> unitTest)
        {
            unitTest.Run(() => new ResponseCookiesMock());
        }

        public static IEnumerable<object[]> Data =>
            new UnitTest<ResponseCookiesMock>[]
            {
                //Class
                new ContextMockUnitTest<ResponseCookiesMock, IResponseCookies>(),
                //Methods
                new MethodInvokeUnitTest<ResponseCookiesMock, IResponseCookies>(
                    t => t.Append(Fakes.String, Fakes.String)
                ),
                new MethodInvokeUnitTest<ResponseCookiesMock, IResponseCookies>(
                    t => t.Append(Fakes.String, Fakes.String, Arg.Any<CookieOptions>())
                ),
                new MethodInvokeUnitTest<ResponseCookiesMock, IResponseCookies>(
                    t => t.Delete(Fakes.String)
                ),
                new MethodInvokeUnitTest<ResponseCookiesMock, IResponseCookies>(
                    t => t.Delete(Fakes.String, Arg.Any<CookieOptions>())
                ),
            }.ToData();
    }
}
