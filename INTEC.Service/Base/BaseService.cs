using System;
using System.Collections.Generic;
using INTEC.Data;
using INTEC.Helpers.Extensions;
using INTEC.Helpers.Infraestructure;
using INTEC.Helpers.Utils;
using INTEC.Models;
using INTEC.Models.Infraestructure;
using INTEC.Repository.Framework;

namespace INTEC.Service.Base
{
    public class BaseService<Vm, Ent> : IBaseService<Vm> where Ent : BaseEntity where Vm : BaseViewModel
    {
        protected IRepository<Ent> Repository;

        public BaseService(IRepository<Ent> repository)
        {
            this.Repository = repository;
        }

        public ServiceResult Delete(Vm viewModel)
        {
            ServiceResult serviceResult = new ServiceResult();

            if (viewModel == null)
            {
                serviceResult.Success = false;
                serviceResult.ResultTitle = "ERROR";
                serviceResult.Messages.Add(Error.GetErrorMessage(Error.EmptyModel));
                return serviceResult;
            }

            try
            {
                Ent toDelete = Repository.GetById((int)viewModel.Id).Data as Ent;

                if(toDelete == null)
                {
                    serviceResult.Success = false;
                    serviceResult.ResultTitle = "ERROR";
                    serviceResult.Messages.Add(Error.GetErrorMessage(Error.RecordNotFound));
                    return serviceResult;
                }

                var sr = Repository.Delete(toDelete);
                serviceResult.Success = sr.Success;
                serviceResult.ResultObject = null;
                serviceResult.ResultTitle = Error.GetErrorMessage(Error.CorrectTransaction);

            }
            catch (Exception ex)
            {
                serviceResult.LogError(ex);
            }

            return serviceResult;
        }

        public ServiceResult GetAll(Vm viewModel)
        {
            ServiceResult serviceResult = new ServiceResult();

            try
            {
                serviceResult.Success = true;
                serviceResult.ResultObject = MapperHelper.Instance.Map<List<Ent>, List<Vm>>(this.Repository.GetAll().Data);
                serviceResult.ResultTitle = Error.GetErrorMessage(Error.CorrectTransaction);
                serviceResult.Messages.Add(serviceResult.ResultTitle);
            }
            catch (Exception ex)
            {
                serviceResult.LogError(ex);
            }

            return serviceResult;
        }

        public ServiceResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetByRowId(string RowId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Insert(Vm viewModel)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(Vm viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
