function walk (steps, footprint, km) {
    let distance  = steps * footprint;
    let speed = km * 1000 / 3600;
    let rest = Math.floor(distance / 500) * 60;
    let time = (distance / speed) + rest;

    let hours = Math.floor(time / 3600).toFixed(0).padStart(2, 0);
    let minutes =Math.floor(time / 60).toFixed(0).padStart(2, 0);;
    let seconds = (time % 60).toFixed(0).padStart(2, 0);;

    console.log(`${hours}:${minutes}:${seconds}`);

}
walk(2564,
    0.70,
    5.5);
