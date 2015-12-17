$(element).click(function MatchElementToPartialView(Elements, Partials) {
    if (Elements instanceof Array) {
        if (Partials instanceof Array) {
            for (var elem in Elements)
            {
                if (elem == element)
                {
                    return Partial[Elements.indexOf(elem)];
                }
            }
        } else {
            alert('Page error. Please contact with the admnistation.');
        }
    } else {
        alert('Page error. Please contact with the admnistation.');
    }

});