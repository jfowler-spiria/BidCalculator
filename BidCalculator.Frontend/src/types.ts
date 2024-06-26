export enum VehicleType {
    Common = 0,
    Luxury = 1
}

export interface CalculationResponse {
    basicFee: number;
    specialFee: number;
    associationFee: number;
    storageFee: number;
    total: number;
}
