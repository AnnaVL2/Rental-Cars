export class SearchCar {
    public constructor(public pickupDate?: Date,
                        public estimatedReturnDate?: Date,
                        public vehicleTypeID?: number,
                        public vehicleID?: number,
                        public branchID?: number,
                        public carImage?: string,
                        public manufacturer?: string,
                        public model?: string,
                        public dailyFee?: number,
                        public overdueFee?: number,
                        public gearType?: string,
                        public productionYear?: number) {
    }
}