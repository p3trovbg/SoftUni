function heroic(text) {
    const heroic = [];
    for (const heroInfo of text) {
        let[heroName, heroLevel, currentItems] = heroInfo.split(' / ');
        let currentLevel = Number(heroLevel);
        let itemsArr = currentItems.split(', ');
        const hero = {
            name: heroName,
            level: currentLevel,
            items: itemsArr
        }
        heroic.push(hero);
    }

    console.log(JSON.stringify(heroic));
}

heroic(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);