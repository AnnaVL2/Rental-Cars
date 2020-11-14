export class Rental {
    public constructor(public rentalCode?: number,
                        public pickupDate?: Date,
                        public estimatedReturnDate?: Date,
                        public actualReturnDate?: Date,
                        public userID?:number,
                        public vehicleID?:number,
                        public userName?:string,
                        public registrationNumber?:number,
                        public manufacturer?:string,
                        public model?: string,
                        public dailyFee?:number,
                        public overdueFee?:number,
                        public image?: string,
                        ) {
    }
}