using OrderManagement.DTO.Requests;
using OrderManagement.DTO.Responses;

namespace OrderManagement.DTO.Mappers
{
	public static class ResponseMappers
	{

		public static OrderRequest ToRequest(this Order src)
		{
			return new OrderRequest
			{
				Id = src.Id,
				Name = src.Name,
				State = src.State,
				Windows = src.Windows.Select(srcWindow => srcWindow.ToRequest()).ToList()
			};
		}

		public static WindowRequest ToRequest(this Window src)
		{
			return new WindowRequest
			{
				Id = src.Id,
				Name = src.Name,
				QuantityOfWindows = src.QuantityOfWindows,
				TotalSubElements = src.TotalSubElements,
				SubElements = src.SubElements.Select(srcSubElement => srcSubElement.ToRequest()).ToList()
			};
		}

		public static SubElementRequest ToRequest(this SubElement src)
		{
			return new SubElementRequest
			{
				Id = src.Id,
				ElementNo = src.ElementNo,
				Type = src.Type,
				Width = src.Width,
				Height = src.Height
			};
		}
	}
}
