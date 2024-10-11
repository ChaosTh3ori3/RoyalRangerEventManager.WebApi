namespace RangerEventManager.Persistence.Entities.Camp;

public class RegistrationEntity 
{
    public long RegistrationId { get; set; }    
    public bool FullNameFields { get; set; } = true;
    public bool GenderField { get; set; } = true;
    public bool BirthDateField { get; set;} = true;
    public bool TroopFields { get; set; } = true;
    public bool ContractField { get; set; } = true;
    public bool FirstContactPersonFields { get; set; } = true;
    public bool SecondContactPersonFields { get; set; }
    public bool AddressFields { get; set; } = true;
    public bool MedicationFields { get; set; } = true;
    public bool AllergiesFields { get; set; }
    public bool DiseasesFields { get; set; }
    public bool HealthInsuranceField { get; set; } = true;
    public bool VaccinationsField { get; set; }
    public bool CanSwimField { get; set; }
    public bool CloatingSizeField { get; set; }
    public bool CoastField { get; set; } = true;
    public float CostFieldValue { get; set; }
    public bool FirstAdditionalField { get; set; }
    public string? FirstAdditionalFieldName { get; set; }
    public bool SecondAdditionalField { get; set; }
    public string? SecondAdditionalFieldName { get; set; }
    public bool ThirdAdditionalField { get; set; }
    public string? ThirdAdditionalFieldName { get; set; }
    
    internal long CampId { get; set; }
    internal CampEntity Camp {get;set;}
}