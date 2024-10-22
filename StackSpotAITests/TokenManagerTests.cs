using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Protected;
using System.Threading;
using StackSpotAI;

namespace StackSpotAITests
{
    public class TokenManagerTests
    {
        [Fact]
        public async Task GenerateToken_ShouldReturnAccessToken()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
              .Setup<Task<HttpResponseMessage>>(
                 "SendAsync",
                 ItExpr.IsAny<HttpRequestMessage>(),
                 ItExpr.IsAny<CancellationToken>()
              )
              .ReturnsAsync(new HttpResponseMessage()
              {
                  StatusCode = System.Net.HttpStatusCode.OK,
                  Content = new StringContent("{\"access_token\":\"test_token\"}")
              });

            var client = new HttpClient(handlerMock.Object);
            var tokenManager = new TokenManager("client_id", "client_secret");

            var token = await tokenManager.GenerateTokenAsync();

            Assert.Equal("test_token", token);
        }
    }
}
