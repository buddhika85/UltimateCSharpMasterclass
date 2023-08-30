﻿namespace CookieCookbookModelAnswer.FileAccess;

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat format) =>
        format == FileFormat.Json ? "json" : "txt";
}