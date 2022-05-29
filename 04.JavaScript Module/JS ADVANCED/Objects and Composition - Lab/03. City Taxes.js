function taxes (cityName, cityPopulation, cityTreasury) {
    const obj = { 
        name: cityName,
        population: cityPopulation,
        treasury: cityTreasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += Math.floor(this.population * this.taxRate);
        },
        applyGrowth(percentage) {
            this.population += Math.floor((percentage * this.population) / 100);
        },
        applyRecession(percentage) {
            this.treasury -= Math.floor((this.treasury * percentage) / 100);
        }
    }

    return obj;
}