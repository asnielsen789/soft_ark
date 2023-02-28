var CreateWordFilterFn = (string[] words) => {
    return (string text) => {
        return string.Join(" ", text.Split(" ").Where(w => !words.Contains(w)));
    };
};

var CreateWordReplacerFn = (string[] words, string replacementWord) => {
    return (string text) => {
        return string.Join(" ", text.Split(" ").Select(w => !words.Contains(w) ? w : replacementWord));
    };
};

var badWords = new string[] { "shit", "fuck", "idiot", "lort" };
//var FilterBadWords = CreateWordFilterFn(badWords);
var FilterBadWords = CreateWordReplacerFn(badWords, "kage");
Console.WriteLine(FilterBadWords("Sikke en gang lort"));
// Udskriver: "Sikke en gang kage"