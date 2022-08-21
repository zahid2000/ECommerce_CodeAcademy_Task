using Core.Utilities.Results;
using Entities;
using Entities.Dto;

namespace Business.Abstract;

public interface IMailService
{
  void SendMail(Mail mail);
}