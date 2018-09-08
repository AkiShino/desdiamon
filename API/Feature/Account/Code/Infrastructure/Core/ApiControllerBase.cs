using Api.Foundation.Data.Infrastructure;
using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Feature.Account.Infrastructure.Core
{
    public class ApiControllerBase :ApiController
    {
        protected readonly IUnitOfWork _unitOfWork;
        public ApiControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiControllerBase(IDataRepositoryFactory dataRepositoryFactory, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            if (request.Method != HttpMethod.Get)
            {
                using (var trans = _unitOfWork.BeginTransaction())
                {
                    try
                    {
                        response = function.Invoke();

                        trans.Commit();
                    }
                    catch (ApiResponseException ex)
                    {
                        response = request.CreateResponse(HttpStatusCode.BadRequest, ex.GetResponseMessage);
                    }
                    catch (DbUpdateException ex)
                    {
                        trans.Rollback();
                        response = request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Bad Request" + ex.ToString() });
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        response = request.CreateResponse(HttpStatusCode.InternalServerError, new { message = "Internal Error" + ex.ToString() });
                    }
                }
            }
            else
            {
                try
                {
                    response = function.Invoke();
                }
                catch (ApiResponseException ex)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ex.GetResponseMessage);
                }
                catch (DbUpdateException ex)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { message = "Bad Request" + ex.ToString() });
                }
                catch (Exception ex)
                {
                    response = request.CreateResponse(HttpStatusCode.InternalServerError, new { message = "Internal Error" + ex.ToString() });
                }
            }

            return response;
        }
    }
}