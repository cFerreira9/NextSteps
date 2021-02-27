using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Next.Steps.Repository.ADO
{
    public class PersonRepositoryADO : IPersonRepository
    {
        private readonly string cs = @"Data Source=DESKTOP-JN31U5B\SQLEXPRESS;" + "Initial Catalog=NextStepsADODatabase;"
                + "Integrated Security=True;" + "User Id=sa;" + "Password=Password1994";

        public bool Create(Person p)
        {
            int recordsAffected;

            string queryString = "INSERT INTO[People](FirstName, LastName, Profession, Birthdate, Email)"
                + "VALUES(@Firstname, @Lastname, @Profession, @Birthdate, @Email)";

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

                    recordsAffected = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception)
                {
                    return false;
                }

                foreach (var hobby in p.Hobbies)
                {
                    queryString = "INSERT INTO[Hobby](Name, Type, PersonId)"
                    + "VALUES(@Name, @Type, @PersonId)";

                    cmd = new SqlCommand(queryString, conn);

                    try
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Name", hobby.Name);
                        cmd.Parameters.AddWithValue("@Type", hobby.Type);
                        cmd.Parameters.AddWithValue("@PersonId", p.Id);

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return recordsAffected > 0;
        }

        public bool Update(Person p)
        {
            int recordsAffected;

            string queryString = "UPDATE People"
                + "SET FirstName = @Firstname, LastName = @Lastname, Profession = @Profession, Birthdate = @Birthdate, Email = @Email"
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

                    recordsAffected = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception)
                {
                    return false;
                }

                foreach (var hobby in p.Hobbies)
                {
                    queryString = "UPDATE Hobby"
                        + "SET Name = @Name, Type = @Type, PersonId = @PersonId)"
                        + "VALUES(@Name, @Type, @PersonId)"
                        + "WHERE Id = @Id";

                    cmd = new SqlCommand(queryString, conn);

                    try
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@Name", hobby.Name);
                        cmd.Parameters.AddWithValue("@Type", hobby.Type);
                        cmd.Parameters.AddWithValue("@PersonId", p.Id);

                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return recordsAffected > 0;
            }
        }

        public bool Delete(int id)
        {
            int recordsAffected;

            string queryString = "DELETE FROM People"
                + "WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    recordsAffected = cmd.ExecuteNonQuery();

                    conn.Close();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return recordsAffected > 0;
        }

        public IEnumerable<Person> GetAll()
        {
            var queryString = "SELECT Id, FirstName, LastName," +
                " Profession, Birthdate, Email"
                + " FROM People";

            var list = new List<Person>();

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    var person = new Person()
                    {
                        Id = (int)dr["Id"],
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"],
                        Profession = (string)dr["Profession"],
                        Birthdate = (DateTime)dr["Birthdate"],
                        Email = (string)dr["Email"]
                    };

                    list.Add(person);
                }
                else
                {
                    list = null;
                }

                dr.Close();
                return list;
            }
        }

        public Person GetById(int id)
        {
            var queryString = "SELECT Id, FirstName, LastName," +
                " Profession, Birthdate, Email"
                + " FROM People"
                + " WHERE Id = @Id";

            using (var conn = new SqlConnection(cs))
            {
                Person person;

                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                cmd.Parameters.AddWithValue("@Id", id);

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    person = new Person()
                    {
                        Id = (int)dr["Id"],
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"],
                        Profession = (string)dr["Profession"],
                        Birthdate = (DateTime)dr["Birthdate"],
                        Email = (string)dr["Email"]
                    };
                }
                else
                {
                    person = null;
                }

                dr.Close();
                return person;
            }
        }

        public IEnumerable<Person> Search(string firstName, string lastName = "")
        {
            var queryString = "SELECT FirstName, LastName"
                + "FROM People"
                + "WHERE FirstName = @Firstname OR LastName = @Lastname";

            var list = new List<Person>();

            using (var conn = new SqlConnection(cs))
            {
                var cmd = new SqlCommand(queryString, conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    var person = new Person()
                    {
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"]
                    };

                    list.Add(person);
                }
                else
                {
                    list = null;
                }

                dr.Close();
                return list;
            }
        }

        public bool Delete(Person p)
        {
            return Delete(p.Id);
        }
    }
}