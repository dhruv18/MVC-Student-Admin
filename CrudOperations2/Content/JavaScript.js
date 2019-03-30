(function ($) {
    $(document).ready(function () {
        uploadImage()

        function uploadImage() {
            var button = $('.images .pic')
            var uploader = $('<input type="file" accept="image/*" />')
            var images = $('.images')

            button.on('click', function () {
                uploader.click()
            })

            uploader.on('change', function () {
                var reader = new FileReader()
                reader.onload = function (event) {
                    images.prepend('<div class="img" style="background-image: url(\'' + event.target.result + '\');" rel="' + event.target.result + '"><span>remove</span></div>')
                }
                reader.readAsDataURL(uploader[0].files[0])

            })

            images.on('click', '.img', function () {
                $(this).remove()
            })

        }
    }
       })(jQuery)
    