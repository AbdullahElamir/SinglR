import addCourses from './AddCourses/AddCourses.vue';
import editCourses from './EditCourses/EditCourses.vue';
import moment from 'moment';
export default {
    name: 'Courses',    
    created() {
        //console.log(this.$route.params.SuperPackageId)
        //console.log(this.$parent.SuperPackageParent);
        //if (this.$parent.SuperPackageParent==null) {
        //    this.$router.push("/Packages/SuperPackages");
        //}
       // this.GetCoursesBySuperPackageId(this.pageNo);  
        //welcome
        this.connectionOne();
        this.conneciontStart();
    },
    components: {
        'add-Courses': addCourses,
        'edit-Courses': editCourses
    },
    filters: {
        moment: function (date) {
            if (date === null) {
                return "فارغ";
            }
           // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
    },
    data() {
        return {
            connection: null,
            count: 0,
            link:0,
        };
    },
    methods: {

        connectionOne() {
            this.connection = new this.$signalR.HubConnectionBuilder()
                .withUrl("http://localhost:5000/count")
                .configureLogging(this.$signalR.LogLevel.Error)
                .build();
        },
        conneciontStart() {
            this.connection.start();
            this.connection.on('increment', data => {
                this.count = data;
            });

            this.connection.on('Link', data => {
                this.link = data;
            });
            
        }
    }    
}
