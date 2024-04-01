var file;

$('input[type=file]').on('change', function (e) {
	file = this.files[0]
});

$('.upload_files').on('click', function (e) {
	let data = new FormData()
	
	data.append('file', file, file.name)
		
	fetch('/Load/Index', {
		method: 'POST',
		body: data,
	})
	.then(response => response.json())
	.then(respond => {
		console.log(respond);
	})
	.catch(error => {
		console.error(error);
	})
});