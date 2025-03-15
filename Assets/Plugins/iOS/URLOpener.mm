// URLOpener.mm
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern "C" {
    bool _OpenURL(const char* url) {
        NSString *urlString = [NSString stringWithUTF8String:url];
        NSURL *nsurl = [NSURL URLWithString:urlString];
        
        if (@available(iOS 10.0, *)) {
            [[UIApplication sharedApplication] openURL:nsurl options:@{} completionHandler:nil];
            return true;
        } else {
            return [[UIApplication sharedApplication] openURL:nsurl];
        }
    }
}
