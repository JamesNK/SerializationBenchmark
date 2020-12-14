namespace SerializationBenchmark
{
    internal static class TestDataDto
    {
        // This is the data we use to serialize/deserialize in the benchmark
        public static readonly UserLicensesResponseDto TestValue = CreateDtos(TestData.TestValue);

        private static UserLicensesResponseDto CreateDtos(UserLicensesResponse testValue)
        {
            var response = new UserLicensesResponseDto();
            foreach (var item in testValue.Licenses)
            {
                var license = new UserLicenseDto
                {
                    ObjectId = item.ObjectId,
                    SkuId = item.SkuId,
                    SkuPartNumber = item.SkuPartNumber
                };

                foreach (var fruitColor in item.FruitColors)
                {
                    license.FruitColors.Add(fruitColor.Key, (ColorDto)fruitColor.Value);
                }

                foreach (var servicePlan in item.ServicePlans)
                {
                    license.ServicePlans.Add(new ServicePlanDto
                    {
                        ServicePlanId = servicePlan.ServicePlanId,
                        ServicePlanName = servicePlan.ServicePlanName,
                        ProvisioningStatus = servicePlan.ProvisioningStatus,
                        AppliesTo = servicePlan.AppliesTo,
                        Count = servicePlan.Count
                    });
                }

                response.Licenses.Add(license);
            }

            return response;
        }
    }
}