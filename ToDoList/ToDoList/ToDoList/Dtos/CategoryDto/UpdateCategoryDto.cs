﻿namespace ToDoList.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}