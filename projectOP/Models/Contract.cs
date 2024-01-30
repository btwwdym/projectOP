using System.Text.Json.Serialization;

namespace app
{
    [JsonConverter(typeof(InterfaceConverter))]
    public interface IContract
    {
        string ContractType { get; } 
        string GetContractDetails(); 
    }


    public class ShippingContract : IContract
    {
        public ShippingContract(string shippingRoute, decimal shippingCost, DateTime deliveryStartDate)
        {
            ShippingRoute = shippingRoute;
            ShippingCost = shippingCost;
            DeliveryStartDate = deliveryStartDate;
        }

        public string ContractType => "Shipping";
        public string ShippingRoute { get; }
        public decimal ShippingCost { get; }
        public DateTime DeliveryStartDate { get; }

        public string GetContractDetails()
        {
            return $"Shipping contract ,Shipping Route: {ShippingRoute}, Shipping Cost: {ShippingCost:C}, Delivery Start Date: {DeliveryStartDate.ToShortDateString()}";
        }
    }

    public class WarehouseLeaseContract : IContract
    {
        public WarehouseLeaseContract(string warehouseLocation, decimal monthlyLeaseCost, DateTime leaseStartDate)
        {
            WarehouseLocation = warehouseLocation;
            MonthlyLeaseCost = monthlyLeaseCost;
            LeaseStartDate = leaseStartDate;
        }

        public string ContractType => "Warehouse Lease";
        public string WarehouseLocation { get; }
        public decimal MonthlyLeaseCost { get; }
        public DateTime LeaseStartDate { get; }

        public string GetContractDetails()
        {
            return $"Warehouse Lease, Warehouse Location: {WarehouseLocation}, Monthly Lease Cost: {MonthlyLeaseCost:C}, Lease Start Date: {LeaseStartDate.ToShortDateString()}";
        }
    }

    public class RoutePlanningContract : IContract
    {
        public RoutePlanningContract(string routePlannerName, decimal planningFee, int planningPeriodInMonths)
        {
            RoutePlannerName = routePlannerName;
            PlanningFee = planningFee;
            PlanningPeriodInMonths = planningPeriodInMonths;
        }

        public string ContractType => "Route Planning";
        public string RoutePlannerName { get; }
        public decimal PlanningFee { get; }
        public int PlanningPeriodInMonths { get; }

        public string GetContractDetails()
        {
            return $"Route Planning Contract, Route Planner: {RoutePlannerName}, Planning Fee: {PlanningFee:C}, Planning Period: {PlanningPeriodInMonths} months";
        }
    }
}
