using SistemaDeBoleteria.Core.Interfaces.IServices;
using SistemaDeBoleteria.Core.Interfaces.IRepositories;
using SistemaDeBoleteria.Core.Enums;
using QRCoder;
namespace SistemaDeBoleteria.Services
{
    public class CodigoQRService : ICodigoQRService
    {
        private readonly ICodigoQRRepository codigoQRRepository;
        public CodigoQRService(ICodigoQRRepository codigoQRRepository)
        {
            this.codigoQRRepository = codigoQRRepository;
        }
        public byte[]? GetQRByEntradaId(int idEntrada)
        {
            var codigoQR = codigoQRRepository.SelectById(idEntrada);
            if (codigoQR is null)
                return null;
            var url = $"http://10.160.27.227:5027/qr/validar?idEntrada={codigoQR.IdEntrada}&Codigo={codigoQR.Codigo}";
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }


        public string ValidateQR(int IdEntrada, string codigo)
        {
            if (!codigoQRRepository.Exists(IdEntrada, codigo))
            {
                return $"{ETipoEstadoQR.NoExiste.ToString()}: caso 1";
            }

            var (DataEntrada, DataFuncion, DataQR) = codigoQRRepository.SelectData(IdEntrada);
            if (DataEntrada is null || DataFuncion is null || DataQR is null)
            {
                return $"{ETipoEstadoQR.FirmaInvalida.ToString()}: caso 2";
            }

            bool esHoy = DataFuncion.Apertura.Date == DateTime.Now.ToLocalTime().Date;
            TimeOnly ahora = TimeOnly.FromDateTime(DateTime.Now.ToLocalTime());
            TimeOnly aperturaTime = TimeOnly.FromDateTime(DataFuncion.Apertura);
            TimeOnly cierreTime = TimeOnly.FromDateTime(DataFuncion.Cierre);

            bool dentroDelHorario = ahora >= aperturaTime && ahora <= cierreTime;

            if (DataEntrada.Anulado is true)
            {
                return $"Entrada anulada. QR no disponible : caso 3";
            }

            if (esHoy)
            {
                if (dentroDelHorario)
                {
                    if (DataQR.TipoEstado == ETipoEstadoQR.Ok)
                    {
                        return $"{codigoQRRepository
                                    .UpdateEstado(IdEntrada, ETipoEstadoQR.YaUsada).ToString()}: caso 5";
                    }
                    if (DataQR.TipoEstado != ETipoEstadoQR.YaUsada)
                    {
                        return $"{codigoQRRepository
                                    .UpdateEstado(IdEntrada, ETipoEstadoQR.Ok).ToString()}: caso 4";
                    }
                    else
                    {
                        return $"{ETipoEstadoQR.YaUsada} : caso 6";
                    }
                }
                else
                {
                    return $"{ETipoEstadoQR.FirmaInvalida.ToString()}: caso 7";
                }
            }
            else if (DateOnly.FromDateTime(DataFuncion.Apertura) < DateOnly.FromDateTime(DateTime.Now.ToLocalTime()))
            {
                return $"{ETipoEstadoQR.Expirada.ToString()}: caso 8";
            }
            return $"{ETipoEstadoQR.FirmaInvalida.ToString()}: caso 9";
        }
    }
}