using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;
using CoreGraphics;

namespace MrqIosSdk
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     CGPoint Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//
	// @interface MRQContent : NSObject
	[BaseType (typeof (NSObject))]
	interface MRQContent {

		// -(id)initWithData:(NSDictionary *)data;
		[Export ("initWithData:")]
		IntPtr Constructor (NSDictionary data);

		// @property (readonly, nonatomic) NSString * content;
		[Export ("content")]
		string Content { get; }

		// @property (readonly, nonatomic) NSString * contentType;
		[Export ("contentType")]
		string ContentType { get; }

		// @property (readonly, nonatomic) NSDictionary * data;
		[Export ("data")]
		NSDictionary Data { get; }

		// @property (readonly, nonatomic) NSString * encoding;
		[Export ("encoding")]
		string Encoding { get; }

		// @property (readonly, nonatomic) CGSize size;
		[Export ("size")]
		CGSize Size { get; }

		// @property (readonly, nonatomic) NSURL * url;
		[Export ("url")]
		NSUrl Url { get; }

		// @property (readonly, nonatomic) NSURL * viewUrl;
		[Export ("viewUrl")]
		NSUrl ViewUrl { get; }

		// @property (readonly, nonatomic) NSString * audienceId;
		[Export ("audienceId")]
		string AudienceId { get; }

		// @property (readonly, nonatomic) NSString * campaignId;
		[Export ("campaignId")]
		string CampaignId { get; }

		// @property (readonly, nonatomic) NSString * creativeId;
		[Export ("creativeId")]
		string CreativeId { get; }

		// -(CGSize)sizeThatFits:(CGSize)size;
		[Export ("sizeThatFits:")]
		CGSize SizeThatFits (CGSize size);
	}

	// @interface MRQSDK : NSObject
	[BaseType (typeof (NSObject))]
	interface MRQSDK {

		// @property (assign, nonatomic) id<MRQSDKDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) id<MRQSDKDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MRQSDKDelegate Delegate { get; set; }

		// @property (copy, nonatomic) NSString * clientID;
		[Export ("clientID")]
		string ClientID { get; set; }

		// @property (copy, nonatomic) NSString * customerID;
		[Export ("customerID")]
		string CustomerID { get; set; }

		// @property (copy, nonatomic) NSString * apiHost;
		[Export ("apiHost")]
		string ApiHost { get; set; }

		// @property (readonly, nonatomic) CLLocation * lastLocation;
		[Export ("lastLocation")]
		CLLocation LastLocation { get; }

		// @property (readonly, nonatomic) NSDictionary * lastNotification;
		[Export ("lastNotification")]
		NSDictionary LastNotification { get; }

		// @property (readonly, nonatomic) NSURL * matchingContentURL;
		[Export ("matchingContentURL")]
		NSUrl MatchingContentURL { get; }

		// @property (readonly, nonatomic) NSArray * matchingContent;
		[Export ("matchingContent")]
		NSObject [] MatchingContent { get; }

		// @property (readonly, nonatomic) NSArray * viewedContent;
		[Export ("viewedContent")]
		NSObject [] ViewedContent { get; }

		// +(MRQSDK *)shared;
		[Static, Export ("shared")]
		MRQSDK Shared ();

		// -(BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool DidFinishLaunchingWithOptions (UIApplication application, NSDictionary launchOptions);

		// -(BOOL)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo;
		[Export ("application:didReceiveRemoteNotification:")]
		bool DidReceiveRemoteNotification (UIApplication application, NSDictionary userInfo);

		// -(void)updateLocation:(CLLocation *)currentLocation;
		[Export ("updateLocation:")]
		void UpdateLocation (CLLocation currentLocation);

		// -(void)startMonitoringLocation;
		[Export ("startMonitoringLocation")]
		void StartMonitoringLocation ();

		// -(BOOL)startMonitoringLocationIfAuthorized;
		[Export ("startMonitoringLocationIfAuthorized")]
		bool StartMonitoringLocationIfAuthorized ();

		// -(void)stopMonitoringLocation;
		[Export ("stopMonitoringLocation")]
		void StopMonitoringLocation ();

		// -(void)registerDeviceToken:(NSData *)deviceToken;
		[Export ("registerDeviceToken:")]
		void RegisterDeviceToken (NSData deviceToken);

		// -(void)refresh;
		[Export ("refresh")]
		void Refresh ();

		// -(void)trackAllContentViewed;
		[Export ("trackAllContentViewed")]
		void TrackAllContentViewed ();

		// -(void)trackContentViewed:(MRQContent *)mrqContent;
		[Export ("trackContentViewed:")]
		void TrackContentViewed (MRQContent mrqContent);
	}

	// @protocol MRQSDKDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MRQSDKDelegate {

		// @required -(NSDictionary *)mrqsdkRequestData:(MRQSDK *)mrq;
		[Export ("mrqsdkRequestData:")]
		[Abstract]
		NSDictionary MrqsdkRequestData (MRQSDK mrq);

		// @required -(void)mrqsdk:(MRQSDK *)mrq updateWithMatches:(NSInteger)matching;
		[Export ("mrqsdk:updateWithMatches:")]
		[Abstract]
		void UpdateWithMatches (MRQSDK mrq, int matching);

		// @optional -(void)mrqsdk:(MRQSDK *)mrq didFailWithError:(NSError *)error;
		[Export ("mrqsdk:didFailWithError:")]
		void DidFailWithError (MRQSDK mrq, NSError error);
	}

	// @protocol MRQContentTableViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface MRQContentTableViewDelegate {

		// @optional -(void)tableView:(UITableView *)tableView content:(MRQContent *)content selectedAtRow:(NSInteger)row;
		[Export ("tableView:content:selectedAtRow:")]
		void Content (UITableView tableView, MRQContent content, int row);

		// @optional -(void)tableView:(UITableView *)tableView content:(MRQContent *)content viewedAtRow:(NSInteger)row;
		[Export ("tableView:content:viewedAtRow:")]
		void Content (UITableView tableView, MRQContent content, int row, bool ignore);
	}

	// @interface MRQContentTableViewController : UIViewController <UITableViewDelegate, UITableViewDataSource, UIWebViewDelegate>
	[BaseType (typeof (UIViewController))]
	interface MRQContentTableViewController /*: UITableViewDelegate, UITableViewDataSource, UIWebViewDelegate */ {

		// @property (assign, nonatomic) id<MRQContentTableViewDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) id<MRQContentTableViewDelegate> delegate;
		[Wrap ("WeakDelegate")]
		MRQContentTableViewDelegate Delegate { get; set; }

		// @property (assign, nonatomic) UITableView * tableView;
		[Export ("tableView", ArgumentSemantic.UnsafeUnretained)]
		UITableView TableView { get; set; }

		// @property (retain, nonatomic) MRQSDK * mrqsdk;
		[Export ("mrqsdk", ArgumentSemantic.Retain)]
		MRQSDK Mrqsdk { get; set; }

		// -(void)reloadContent;
		[Export ("reloadContent")]
		void ReloadContent ();
	}
}

