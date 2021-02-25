using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Next.Steps.Repository.ADO
{
    public class PersonRepositoryADO : IPersonRepository
    {
        private string cs = @"Data Source=DESKTOP-JN31U5B\SQLEXPRESS" + "Initial Catalog=CarlosFerreira_Project"
                + "Integrated Security=True" + "User Id=sa" + "Password=Password1994";

        public bool Create(Person p)
        {
            string queryString = "INSERT INTO[Person](Firstname, Lastname, Profession, Birthdate, Email, Hobbies)"
                + "VALUES(@Firstname, @Lastname, @Profession, @Birthdate, @Email, @Hobbies)";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Firstname", p.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", p.LastName);
                    cmd.Parameters.AddWithValue("@Profession", p.Profession);
                    cmd.Parameters.AddWithValue("@Birthdate", p.Birthdate);
                    cmd.Parameters.AddWithValue("@Email", p.Email);
                    cmd.Parameters.AddWithValue("@Hobbies", p.Hobbies);

                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool Update(Person p)
        {
            string queryString = "UPDATE Person"
                + "SET Firstname = @Firstname, LastName = @Lastname, Profession = @Profession, Birthdate = @Birthdate, Email = @Email, Hobbies = @Hobbies"
                + "WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("@Firstname", p.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", p.LastName);
                    cmd.Parameters.AddWithValue("@Profession", p.Profession);
                    cmd.Parameters.AddWithValue("@Birthdate", p.Birthdate);
                    cmd.Parameters.AddWithValue("@Email", p.Email);
                    cmd.Parameters.AddWithValue("@Hobbies", p.Hobbies);

                    conn.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            string queryString = "DELETE FROM Users"
                + "WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Close();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public IEnumerable<Person> GetAll()
        {
            var queryString = "SELECT Person.Firstname, Person.Lastname, Person.Profession, Person.Birthdate, Person.Email, Person.Hobbies"
                + "FROM Person";

            var list = new List<Person>();

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var person = new Person()
                        {
                            Id = (int)dr["Id"],
                            FirstName = (string)dr["Firstname"],
                            LastName = (string)dr["Lastname"],
                            Profession = (string)dr["Profession"],
                            Birthdate = (DateTime)dr["Birthdate"],
                            Email = (string)dr["Email"],
                            Hobbies = (List<Hobby>)dr["Hobbies"]
                        };

                        dr.Close();
                        list.Add(person);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return list;
        }

        public Person GetById(int id)
        {
            var queryString = "SELECT Person.Firstname, Person.Lastname, Person.Profession, Person.Birthdate, Person.Email, Person.Hobbies"
                + "FROM Person"
                + "WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var person = new Person()
                        {
                            Id = (int)dr["Id"],
                            FirstName = (string)dr["Firstname"],
                            LastName = (string)dr["Lastname"],
                            Profession = (string)dr["Profession"],
                            Birthdate = (DateTime)dr["Birthdate"],
                            Email = (string)dr["Email"],
                            Hobbies = (List<Hobby>)dr["Hobbies"]
                        };
                        return person;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }

        public IEnumerable<Person> Search(string firstName, string lastName = "")
        {
            var queryString = "SELECT Person.Firstname, Person.Lastname"
                + "FROM Person"
                + "WHERE Firstname = @Firstname";

            var list = new List<Person>();

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        var person = new Person()
                        {
                            FirstName = (string)dr["Firstname"],
                            LastName = (string)dr["Lastname"]
                        };

                        dr.Close();
                        list.Add(person);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return list;
        }
    }
}