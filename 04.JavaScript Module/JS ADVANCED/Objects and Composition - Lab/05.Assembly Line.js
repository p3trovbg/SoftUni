function createAssemblyLine() {
    const library = {
        hasClima(obj) {
            obj['temp'] = 21;
            obj['tempSettings'] = 21;
            obj['adjustTemp'] = () => obj.temp < obj.tempSettings ? obj.temp++ : obj.temp--;
        },
        hasAudio(obj) {
            obj['currentTrack'] = null;
            obj['nowPlaying'] = () => {
                if (obj.currentTrack !== null) {
                    console.log(`Now playing '${currentTrack.name}' by ${currentTrack.artist}`)
                }
            }
        },
        hasParktronic(obj) {
            obj['checkDistance'] = distance => console.log(distance < 0.1 ? 'Beep! Beep! Beep!' :
            distance < 0.25 ? 'Beep! Beep!' : distance < 0.5 ? 'Beep!' : '');
        }
    }

    return library;
}

const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};
