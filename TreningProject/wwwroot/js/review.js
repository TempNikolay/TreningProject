let table = document.querySelector('.scrollTable');
let scrollableDiv = document.querySelector('.table-scrollbar');
let loadingData = false;

scrollableDiv.addEventListener('scroll', function () {
    if (loadingData) return;

    if (scrollableDiv.scrollTop + scrollableDiv.clientHeight >= table.clientHeight) {
        loadingData = true;
        let element = $('.byYears');
        let grouping = 1;

        if (element.hasClass('active')) {
            grouping = 0;
        }

        let page = $('.pages .active a').html()

        fetch(`/Review/LoadMore?grouping=${grouping}&currentPage=${page}&skip=${table.rows.length}`)
            .then(response => response.json())
            .then(data => {
                data.forEach(item => {
                    console.log(item);
                    let row = document.createElement('tr')
                    row.innerHTML =
                        `<td>${item.dateTime}</td>` +
                        `<td>${item.airTemperature}</td>` +
                        `<td>${item.relativeHumidity}</td>` +
                        `<td>${item.racePoint}</td>` +
                        `<td>${item.atmosphericPressure}</td>` +
                        `<td>${item.windDirection}</td>` +
                        `<td>${item.windSpeed !== null ? item.windSpeed : ''}</td>` +
                        `<td>${item.cloudCover !== null ? item.cloudCover : ''}</td>` +
                        `<td>${item.lowerBound}</td>` +
                        `<td>${item.horizontalVisibility !== null ? item.horizontalVisibility : ''}</td>` +
                        `<td>${item.weatherPhenomenon !== null ? item.weatherPhenomenon : ''}</td>`

                    table.querySelector('tbody').appendChild(row)
                });
                loadingData = false;
            });
    }
});