export class VehicleType {
    public constructor(public vehicleTypeID?: number,
                        public manufacturer?: string,
                        public model?: string,
                        public dailyFee?: number,
                        public overdueFee?: number,
                        public gearType?: string,
                        public productionYear?: number) {
    }
}