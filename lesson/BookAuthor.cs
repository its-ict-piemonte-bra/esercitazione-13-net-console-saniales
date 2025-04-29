using System.Diagnostics;

namespace lesson
{
    class BookAuthor
    {
        private static int lastID = 1;

        public readonly int ID;
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateOnly Birthday;

        public BookAuthor(int ID, string FirstName, string LastName, DateOnly Birthday)
        {
            if (ID <= 0)
            {
                throw new ArgumentException("ID is invalid");
            }
            else if (string.IsNullOrWhiteSpace(FirstName))
            {
                throw new ArgumentException("first name is invalid");
            }
            else if (string.IsNullOrWhiteSpace(LastName))
            {
                throw new ArgumentException("last name is invalid");
            }

            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Birthday = Birthday;
        }

        /// <summary>
        /// Creates a new anonymous (unknown) author.
        /// </summary>
        /// <param name="ID">The ID of the author</param>
        public BookAuthor(int ID)
            : this(ID, "Unknown", "Author", default(DateOnly))
        { }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }
            else if (!(obj is BookAuthor))
            {
                return false;
            }

            BookAuthor author = (BookAuthor)obj;

            return this.ID.Equals(author.ID) &&
                this.FirstName.Equals(author.FirstName) &&
                this.LastName.Equals(author.LastName) &&
                this.Birthday.Equals(author.Birthday);
        }

        public override string ToString()
        {
            return $"ID: {this.ID} - Name: {this.FirstName} {this.LastName} - Birthday: {this.Birthday.ToString("dd/MM/yyyy")}";
        }
    }
}
